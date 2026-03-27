using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studentmanagement.Data;
using Studentmanagement.Services;
using StudentManagement.Shared.Models;
using StudentManagement.Shared.StudentRepository;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;

namespace Studentmanagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemCodesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ISystemCodeRepository _systemCodeRepository;
        public SystemCodesController(ISystemCodeRepository systemCodeRepository,ApplicationDbContext context)
        {
            _context = context;
            _systemCodeRepository = systemCodeRepository;

        }

        // GET: api/SystemCodes
        [HttpGet("All-Systemcode")]
        public async Task<ActionResult<IEnumerable<SystemCode>>> GetSystemCodes()
        {
            var code = await _systemCodeRepository.GetAllAsync();

            return Ok(code);
        }

        // GET: api/SystemCodes/5
        [HttpGet("Single-Systemcode/{id}")]
        public async Task<ActionResult<SystemCode>> GetSystemCode(int id)
        {
            var data = await _systemCodeRepository.GetByIdAsync(id);
            return Ok(data);
        }

        // PUT: api/SystemCodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Update-SystemCode")]
        public async Task<ActionResult<SystemCode>> UpdateStudentAsync(SystemCode systemcode)
        {
            var updatedcode = await _systemCodeRepository.UpdateAsync(systemcode);

            return Ok(updatedcode);
        }

        // POST: api/SystemCodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add-SystemCode")]
        public async Task<ActionResult<SystemCode>> PostSystemCode(SystemCode systemCode)
        {
            var newcode = await _systemCodeRepository.AddAsync(systemCode);

            return Ok(newcode);
        }

        // DELETE: api/SystemCodes/5
        [HttpDelete("Delete-SystemCode/{id}")]
        public async Task<IActionResult> DeleteSystemCode(int id)
        {
            var deletedcode = await _systemCodeRepository.DeleteAsync(id);

            return Ok(deletedcode);
        }
    }
}
