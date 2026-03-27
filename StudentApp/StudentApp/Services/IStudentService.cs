using StudentApp.Models;
using System.Collections.Generic;

namespace StudentApp.Services
{
    public interface IStudentService
    {
        List<Student> GetStudents();
    }
}
