using ConsoleApp4.Fake.Interface;
using ConsoleApp4.Fake.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Fake.Service
{
    public class StudentService
    {
        private readonly IStudentRepository _Repo;
        public StudentService(IStudentRepository repo)
        {
            _Repo = repo;
        }
        public Student Get(int id)
        {
            return _Repo.getbyId(id);
        }
    }
}
