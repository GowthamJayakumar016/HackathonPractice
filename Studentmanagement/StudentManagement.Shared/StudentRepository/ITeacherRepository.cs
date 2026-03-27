using StudentManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Shared.StudentRepository
{
    public interface ITeacherRepository
    {
        Task<Teacher> AddAsync(Teacher mod);

        Task<Teacher> UpdateAsync(Teacher mod);

        Task<Teacher> DeleteAsync(int id);

        Task<List<Teacher>> GetAllAsync();

        Task<Teacher> GetByIdAsync(int id);

    }
}
