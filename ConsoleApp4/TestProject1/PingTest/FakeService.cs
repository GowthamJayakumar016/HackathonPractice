using ConsoleApp4.Fake.Interface;
using ConsoleApp4.Fake.Models;
using ConsoleApp4.Fake.Service;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using FakeItEasy;

namespace TestProject1.PingTest
{
    public class FakeService
    {
        [Fact]
        public void FakeService_get_return()
        {
            var Fakerepo = A.Fake<IStudentRepository>();
            var student = new Student { Id = 1, Name = "Aravind" };
            A.CallTo(()=>Fakerepo.getbyId(1)).Returns(student);
            var service=new StudentService(Fakerepo);
            //Act
            var result = service.Get(1);
            result.Name.Should().Be("Aravind");
            result.Should().NotBeNull();

        }
    }
}
