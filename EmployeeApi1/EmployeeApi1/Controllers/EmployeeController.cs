using EmployeeApi1.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Aravind", Department = "IT" },
                new Employee { Id = 2, Name = "Kumar", Department = "Banking" }
            };

            return Ok(employees);
        }
    }
}