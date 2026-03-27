using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
        [ApiController]
        public class StudentsController : ControllerBase
        {
            [HttpGet]
            public IActionResult GetStudents()
            {
                var students = new List<string>
            {
                "Aravind",
                "Rahul",
                "Priya"
            };

                return Ok(students);
            }
        }
}
