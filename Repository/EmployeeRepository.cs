using System;
using System.Data;
using System.Data.SqlClient;
using Neosoft_Ankita_Khokale_04March2025.Data;
using Neosoft_Ankita_Khokale_04March2025.Models;
using Microsoft.Extensions.Logging;

namespace Neosoft_Ankita_Khokale_04March2025.Repository
{
    public class EmployeeRepository
    {
        private readonly DbHelper _dbHelper;
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(DbHelper dbHelper, ILogger<EmployeeRepository> logger)
        {
            _dbHelper = dbHelper;
            _logger = logger;
        }

        // Get All Employees
        public List<Employee> GetEmployees()
        {
            try
            {
                DataTable dt = _dbHelper.ExecuteStoredProcedure("stp_Emp_GetAll");
                List<Employee> employees = new List<Employee>();

                foreach (DataRow row in dt.Rows)
                {
                    employees.Add(new Employee
                    {
                        Row_Id = Convert.ToInt32(row["Row_Id"]),
                        EmployeeCode = row["EmployeeCode"].ToString(),
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString(),
                        EmailAddress = row["EmailAddress"].ToString(),
                        MobileNumber = row["MobileNumber"].ToString(),
                        PanNumber = row["PanNumber"].ToString(),
                        PassportNumber = row["PassportNumber"].ToString(),
                        Gender = Convert.ToInt32(row["Gender"]),
                        IsActive = Convert.ToBoolean(row["IsActive"]),
                        DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                        DateOfJoinee = row["DateOfJoinee"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["DateOfJoinee"]),
                        CountryId = Convert.ToInt32(row["CountryId"]),
                        CountryName = row["CountryName"].ToString(),  
                        StateId = Convert.ToInt32(row["StateId"]),
                        StateName = row["StateName"].ToString(),  
                        CityId = Convert.ToInt32(row["CityId"]),
                        CityName = row["CityName"].ToString(),  
                    });
                }

                _logger.LogInformation("Employees fetched successfully", employees.Count);
                return employees;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching employees");
                throw;
            }
        }

        // Get Employee By ID
        public Employee GetEmployeeById(int id)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@EmployeeId", id) };
                DataTable dt = _dbHelper.ExecuteStoredProcedure("stp_Emp_GetById", parameters);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    var employee = new Employee
                    {
                        Row_Id = Convert.ToInt32(row["Row_Id"]),
                        EmployeeCode = row["EmployeeCode"].ToString(),
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString(),
                        CountryId = Convert.ToInt32(row["CountryId"]),
                        StateId = Convert.ToInt32(row["StateId"]),
                        CityId = Convert.ToInt32(row["CityId"]),
                        EmailAddress = row["EmailAddress"].ToString(),
                        MobileNumber = row["MobileNumber"].ToString(),
                        PanNumber = row["PanNumber"].ToString(),
                        PassportNumber = row["PassportNumber"].ToString(),
                        Gender = Convert.ToInt32(row["Gender"]),
                        IsActive = Convert.ToBoolean(row["IsActive"]),
                        DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                        DateOfJoinee = row["DateOfJoinee"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["DateOfJoinee"]),
                    };
                    _logger.LogInformation("Employee information fetched successfully", id);
                    return employee;
                }
                else
                {
                    _logger.LogInformation("Employee Not Found", id);
                    return null;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error fetching employee", id);
                throw;
            }
        }

        // Add New Employee
        public void AddEmployee(Employee employee)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@FirstName", employee.FirstName),
                new SqlParameter("@LastName", employee.LastName),
                new SqlParameter("@CountryId", employee.CountryId),
                new SqlParameter("@StateId", employee.StateId),
                new SqlParameter("@CityId", employee.CityId),
                new SqlParameter("@EmailAddress", employee.EmailAddress),
                new SqlParameter("@MobileNumber", employee.MobileNumber),
                new SqlParameter("@PanNumber", employee.PanNumber),
                new SqlParameter("@PassportNumber", employee.PassportNumber),
                new SqlParameter("@Gender", employee.Gender),
                new SqlParameter("@IsActive", employee.IsActive),
                new SqlParameter("@DateOfBirth", employee.DateOfBirth),
                new SqlParameter("@DateOfJoinee", employee.DateOfJoinee)
                };

                _dbHelper.ExecuteStoredProcedure("stp_Emp_Insert", parameters);
                _logger.LogInformation("New employee added successfully");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error adding employee");
                throw;
            }
        }

        // Update Employee 
        public void UpdateEmployee(Employee employee)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Row_Id", employee.Row_Id),
                    new SqlParameter("@FirstName", employee.FirstName),
                    new SqlParameter("@LastName", employee.LastName),
                    new SqlParameter("@CountryId", employee.CountryId),
                    new SqlParameter("@StateId", employee.StateId),
                    new SqlParameter("@CityId", employee.CityId),
                    new SqlParameter("@EmailAddress", employee.EmailAddress),
                    new SqlParameter("@MobileNumber", employee.MobileNumber),
                    new SqlParameter("@PanNumber", employee.PanNumber),
                    new SqlParameter("@PassportNumber", employee.PassportNumber),
                    new SqlParameter("@Gender", employee.Gender),
                    new SqlParameter("@IsActive", employee.IsActive),
                    new SqlParameter("@DateOfBirth", employee.DateOfBirth),
                    new SqlParameter("@DateOfJoinee", employee.DateOfJoinee)
                };

                _dbHelper.ExecuteStoredProcedure("stp_Emp_Update", parameters);
                _logger.LogInformation("Successfully updated employee", employee.Row_Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating employee", employee.Row_Id);
                throw;
            }
        }

        // Delete Employee
        public void DeleteEmployee(int id)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@EmployeeId", id) };
                _dbHelper.ExecuteStoredProcedure("stp_Emp_Delete", parameters);
                _logger.LogInformation("Employee deleted successfully", id);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error in deleting employee", id);
                throw;
            }
        }
    }
}