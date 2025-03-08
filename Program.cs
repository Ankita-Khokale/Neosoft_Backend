using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Neosoft_Ankita_Khokale_04March2025.Repository;
using Neosoft_Ankita_Khokale_04March2025.Data;

var builder = WebApplication.CreateBuilder(args);

//Add Cors
builder.Services.AddCors(options
    => options.AddPolicy("corsapp", policy =>
{
    policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.MSSqlServer(
        connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
        sinkOptions: new MSSqlServerSinkOptions
        {
            TableName = "ExceptionLog",
            AutoCreateSqlTable = true // This creates the table if it doesn't exist
        },
        restrictedToMinimumLevel: LogEventLevel.Error)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbHelper first
builder.Services.AddScoped<DbHelper>();

// Register All Repository after DbHelper
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<CountryRepository>();
builder.Services.AddScoped<StateRepository>();
builder.Services.AddScoped<CityRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

// Enable Serilog request logging middleware
app.UseSerilogRequestLogging();

// Enabled CORS before any middleware
app.UseCors("corsapp");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();