using Microsoft.AspNetCore.Mvc;
using Neosoft_Ankita_Khokale_04March2025.Models;
using Neosoft_Ankita_Khokale_04March2025.Repository;

namespace Neosoft_Ankita_Khokale_04March2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _repo;
        public EmployeeController(EmployeeRepository repo)
        {
            _repo = repo;
        }


        // GET: api/Employee
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            return Ok(_repo.GetEmployees());
        }

        // GET: api/Employee/{id}
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = _repo.GetEmployeeById(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult AddEmployee([FromForm] Employee employee)
        {
            _repo.AddEmployee(employee);
            return Ok("Employee added successfully");
        }

        // PUT: api/employee/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromForm] Employee employee)
        {
            employee.Row_Id = id;
            if (employee == null || id != employee.Row_Id)
            {
                return BadRequest("Employee ID mismatch or data is null.");
            }

            _repo.UpdateEmployee(employee);
            return Ok("Employee updated successfully");
        }

        // DELETE: api/Employee/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            _repo.DeleteEmployee(id);
            return Ok("Employee deleted successfully");
        }
    }
}