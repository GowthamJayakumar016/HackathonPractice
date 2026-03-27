using ConsoleApp4.Fake.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Fake.Interface
{
    public interface IStudentRepository
    {
        Student getbyId(int id);
    }
}
