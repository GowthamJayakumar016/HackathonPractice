using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Studentmanagement.Data;
using Studentmanagement.Services;
using StudentManagement.Shared.Models;
using StudentManagement.Shared.StudentRepository;

namespace Studentmanagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentRepository _parentRepository;

        public ParentController(IParentRepository parentRepository)
        {
            _parentRepository = parentRepository;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<Parent>>> Getparent()
        {
            var parent = await _parentRepository.GetAllAsync();

            return Ok(parent);
        }

        // GET: api/Countries/5
        [HttpGet("single-Parent /{id}")]
        public async Task<ActionResult<Parent>> GetByIdAsyn(int id)
        {
            var parent = await _parentRepository.GetByIdAsync(id);
            return Ok(parent);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Update-parent")]
        public async Task<ActionResult<Parent>> UpdateStudentAsync(Parent parent)
        {
            var updateparent = await _parentRepository.UpdateAsync(parent);

            return Ok(updateparent);
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add-parent")]
        public async Task<ActionResult<Parent>> PostCountry(Parent parent)
        {
            var newparent = await _parentRepository.AddAsync(parent);

            return Ok(newparent);
        }

        // DELETE: api/Countries/5
        [HttpDelete("Delete-Parent/{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var deleteparent = await _parentRepository.DeleteAsync(id);

            return Ok(deleteparent);
        }


    }
}
