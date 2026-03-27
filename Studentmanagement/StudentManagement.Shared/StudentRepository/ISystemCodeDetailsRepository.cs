using StudentManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Shared.StudentRepository
{
    public interface ISystemCodeDetailsRepository
    {
        Task<SystemCodeDetail> AddAsync(SystemCodeDetail mod);

        Task<SystemCodeDetail> UpdateAsync(SystemCodeDetail mod);

        Task<SystemCodeDetail> DeleteAsync(int id);

        Task<List<SystemCodeDetail>> GetAllAsync();

        Task<SystemCodeDetail> GetByIdAsync(int id);

        Task<List<SystemCodeDetail>> GetByCodeAsync(string code);
    }
}
