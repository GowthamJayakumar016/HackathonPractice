using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Studentmanagement.Data;
using StudentManagement.Shared.Models;
using StudentManagement.Shared.StudentRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentmanagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemCodeDetailsController : ControllerBase
    {
        private readonly ISystemCodeDetailsRepository _repository;

        public SystemCodeDetailsController(ISystemCodeDetailsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<SystemCodeDetail>>> GetAll()
        {
            var data = await _repository.GetAllAsync();
            return Ok(data);
        }

        // GET: api/SystemCodeDetails/Single/5
        [HttpGet("Single/{id}")]
        public async Task<ActionResult<SystemCodeDetail>> GetById(int id)
        {
            var data = await _repository.GetByIdAsync(id);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        // GET: api/SystemCodeDetails/AllByCode/GEN
        [HttpGet("AllByCode/{code}")]
        public async Task<ActionResult<IEnumerable<SystemCodeDetail>>> GetByCode(string code)
        {
            var data = await _repository.GetByCodeAsync(code);
            return Ok(data);
        }

        // POST: api/SystemCodeDetails/Add
        [HttpPost("Add")]
        public async Task<ActionResult<SystemCodeDetail>> Add(SystemCodeDetail model)
        {
            var created = await _repository.AddAsync(model);
            return Ok(created);
        }

        // PUT: api/SystemCodeDetails/Update
        [HttpPut("Update")]
        public async Task<ActionResult<SystemCodeDetail>> Update(SystemCodeDetail model)
        {
            var updated = await _repository.UpdateAsync(model);

            if (updated == null)
                return BadRequest();

            return Ok(updated);
        }

        // DELETE: api/SystemCodeDetails/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<SystemCodeDetail>> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);

            if (deleted == null)
                return NotFound();

            return Ok(deleted);
        }

    }
}
