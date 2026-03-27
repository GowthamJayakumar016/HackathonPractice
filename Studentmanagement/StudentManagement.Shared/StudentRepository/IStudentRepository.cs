using Studentmanagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Shared.StudentRepository
{
    public interface IStudentRepository
    {
        Task<Student> AddStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(Student student);

        Task<Student> DeleteStudentAsync(int studentId);
        Task<List<Student>>GetStudentsAsync();
        Task<Student> GetStudentsByIdAsync(int studentId);


    }
}
