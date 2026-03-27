using Microsoft.AspNetCore.Mvc;
using EMS.API.Models;
using EMS.API.Data;

namespace EMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;
        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Employees.ToList());
        }
        [HttpPost]
        public IActionResult Addp(Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
            return Ok(emp);
        }
        [HttpPut("{id}")]
        public IActionResult update(Employee emp, int id)
        {
            var existing = _context.Employees.Find(id);
            if (existing == null) return NotFound();

            existing.Name = emp.Name;
            existing.Email = emp.Email;
            existing.Salary = emp.Salary;
            existing.DepartmentId = emp.DepartmentId;

            _context.SaveChanges();
            return Ok(existing);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp == null) return NotFound();

            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return Ok();
        }
    }
}
