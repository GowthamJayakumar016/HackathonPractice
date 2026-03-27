using StudentApp.Models;
using System.Collections.Generic;

namespace StudentApp.Services
{
    public class StudentService : IStudentService
    {
        public List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student { Id = 1, Name = "Aravind", Age = 20 },
                new Student { Id = 2, Name = "Kumar", Age = 21 }
            };
        }
    }
}
