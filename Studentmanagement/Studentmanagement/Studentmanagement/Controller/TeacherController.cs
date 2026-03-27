using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Studentmanagement.Services;
using StudentManagement.Shared.Models;
using StudentManagement.Shared.StudentRepository;

namespace Studentmanagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _repo;
        public TeacherController(ITeacherRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeacher()
        {
            var teacher = await _repo.GetAllAsync();

            return Ok(teacher);
        }

        // GET: api/Countries/5
        [HttpGet("single-teacher /{id}")]
        public async Task<ActionResult<Teacher>> GetByIdAsyn(int id)
        {
            var teacher = await _repo.GetByIdAsync(id);
            return Ok(teacher);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Update-teacher")]
        public async Task<ActionResult<Teacher>> UpdateStudentAsync(Teacher teacher)
        {
            var updateteacher = await _repo.UpdateAsync(teacher);

            return Ok(updateteacher);
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add-teacher")]
        public async Task<ActionResult<Teacher>> PostCountry(Teacher teacher)
        {
            var newteacher = await _repo.AddAsync(teacher);

            return Ok(newteacher);
        }

        // DELETE: api/Countries/5
        [HttpDelete("Delete-teacher/{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var deleteteacher = await _repo.DeleteAsync(id);

            return Ok(deleteteacher);
        }
    }
}
