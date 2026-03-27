using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Studentmanagement.Models;
using StudentManagement.Shared.StudentRepository;

namespace Studentmanagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet("All-students")]
        public async Task<ActionResult<List<Student>>> GetAllStudentAsync()
        {
            var student = await _studentRepository.GetStudentsAsync();
            return Ok(student);
        }
        [HttpGet("single-student /{id}")]
        public async Task<ActionResult<Student>> GetSingleStudentAsync(int id)
        {
            var student = await _studentRepository.GetStudentsByIdAsync(id);
            return Ok(student);
        }
        [HttpPost("Add-students")]
        public async Task<ActionResult<Student>> AddNewStudentAsync(Student student)
        {
            var newstudent = await _studentRepository.AddStudentAsync(student);
            return Ok(newstudent);
        }
        [HttpDelete("Delete-student /{id}")]
        public async Task<ActionResult<Student>> DeleteStudentAsync(int id)
        {
            var deletestudent = await _studentRepository.DeleteStudentAsync(id);
            return Ok(deletestudent);
        }
        [HttpPost("Update-Student")]
        public async Task<ActionResult<Student>> UpdateStudentAsync(Student student)
        {
            var updatestudent = await _studentRepository.UpdateStudentAsync(student);
            return Ok(updatestudent);
        }



    }
}
