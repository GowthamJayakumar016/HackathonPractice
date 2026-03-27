using Microsoft.AspNetCore.Mvc;
using StudentApp.Services;

namespace StudentApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var students = _service.GetStudents();
            return View(students);
        }
    }
}
