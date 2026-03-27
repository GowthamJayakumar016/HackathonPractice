using Studentmanagement.Models;
using StudentManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace StudentManagement.Shared.StudentRepository
{
    public interface ICountryRepository
    {
        Task<Country> AddAsync(Country mod);
        Task<Country> UpdateAsync(Country mod);

        Task<Country> DeleteAsync(int Id);
        Task<List<Country>> GetAsync();
        Task<Country> GetByIdAsync(int Id);
    }
}
