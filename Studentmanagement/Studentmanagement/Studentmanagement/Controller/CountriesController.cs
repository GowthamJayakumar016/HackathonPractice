using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studentmanagement.Data;
using Studentmanagement.Models;
using Studentmanagement.Services;
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
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        private readonly ApplicationDbContext _context;
        public CountriesController(ICountryRepository countryRepository, ApplicationDbContext context)
        {
            this._countryRepository = countryRepository;
            _context = context;
        }

        // GET: api/Countries
        [HttpGet("All-Country")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            var countries = await _countryRepository.GetAsync();

            return Ok(countries);
        }

        // GET: api/Countries/5
        [HttpGet("single-Country /{id}")]
        public async Task<ActionResult<Country>> GetByIdAsyn(int id)
        {
            var student = await _countryRepository.GetByIdAsync(id);
            return Ok(student);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Update-Country")]
        public async Task<ActionResult<Country>> UpdateStudentAsync(Country country)
        {
            var updateCountry = await _countryRepository.UpdateAsync(country);

            return Ok(updateCountry);
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add-Countries")]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            var newcountry = await _countryRepository.AddAsync(country);

            return Ok(newcountry);
        }

        // DELETE: api/Countries/5
        [HttpDelete("Delete-Countries/{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var deletecountry = await _countryRepository.DeleteAsync(id);

            return Ok(deletecountry);
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}
