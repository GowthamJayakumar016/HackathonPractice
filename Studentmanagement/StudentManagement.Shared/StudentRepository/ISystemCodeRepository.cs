using StudentManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Shared.StudentRepository
{
    public interface ISystemCodeRepository
    {
        Task<SystemCode> AddAsync(SystemCode mod);

        Task<SystemCode> UpdateAsync(SystemCode mod);

        Task<SystemCode> DeleteAsync(int id);

        Task<List<SystemCode>> GetAllAsync();

        Task<SystemCode> GetByIdAsync(int id);
    }

}
