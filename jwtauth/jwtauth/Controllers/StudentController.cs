using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace jwtauth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult GetStudent()
        {
            return Ok("This is protected data");
        }
    }
}
