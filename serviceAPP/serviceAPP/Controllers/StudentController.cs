using Microsoft.AspNetCore.Mvc;
using serviceAPP.Services;

namespace serviceAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly IMyService _service;
        public StudentController(IMyService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetMessage());
        }
    }
}
