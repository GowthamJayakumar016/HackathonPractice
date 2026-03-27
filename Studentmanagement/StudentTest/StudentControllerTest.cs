//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace StudentTest
//{
//    internal class StudentControllerTest
//    {
//    }
//}
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Studentmanagement.Controller;
using Studentmanagement.Models;
using StudentManagement.Shared.StudentRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentTest
{
    public class StudentControllerTests
    {
        private readonly Mock<IStudentRepository> _mockRepo;
        private readonly StudentController _controller;

        public StudentControllerTests()
        {
            _mockRepo = new Mock<IStudentRepository>();
            _controller = new StudentController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllStudentAsync_ReturnsOkResult_WithListOfStudents()
        {
            // Arrange
            var students = new List<Student>
            {
                new Student { Id = 1, Firstname = "John" },
                new Student { Id = 2, Firstname = "Jane" }
            };
            _mockRepo.Setup(repo => repo.GetStudentsAsync())
                     .ReturnsAsync(students);

            // Act
            var result = await _controller.GetAllStudentAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnStudents = Assert.IsType<List<Student>>(okResult.Value);
            Assert.Equal(2, returnStudents.Count);
        }

        [Fact]
        public async Task GetSingleStudentAsync_ReturnsOkResult_WithStudent()
        {
            // Arrange
            var student = new Student { Id = 1, Firstname = "John" };
            _mockRepo.Setup(repo => repo.GetStudentsByIdAsync(1))
                     .ReturnsAsync(student);

            // Act
            var result = await _controller.GetSingleStudentAsync(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnStudent = Assert.IsType<Student>(okResult.Value);
            Assert.Equal("John", returnStudent.Firstname);
        }

        [Fact]
        public async Task AddNewStudentAsync_ReturnsOkResult_WithNewStudent()
        {
            // Arrange
            var student = new Student { Id = 3, Firstname = "Alice" };
            _mockRepo.Setup(repo => repo.AddStudentAsync(student))
                     .ReturnsAsync(student);

            // Act
            var result = await _controller.AddNewStudentAsync(student);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnStudent = Assert.IsType<Student>(okResult.Value);
            Assert.Equal("Alice", returnStudent.Firstname);
        }

        [Fact]
        public async Task DeleteStudentAsync_ReturnsOkResult_WithDeletedStudent()
        {
            // Arrange
            var student = new Student { Id = 1, Firstname = "John" };
            _mockRepo.Setup(repo => repo.DeleteStudentAsync(1))
                     .ReturnsAsync(student);

            // Act
            var result = await _controller.DeleteStudentAsync(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnStudent = Assert.IsType<Student>(okResult.Value);
            Assert.Equal(1, returnStudent.Id);
        }

        [Fact]
        public async Task UpdateStudentAsync_ReturnsOkResult_WithUpdatedStudent()
        {
            // Arrange
            var student = new Student { Id = 1, Firstname = "Updated John" };
            _mockRepo.Setup(repo => repo.UpdateStudentAsync(student))
                     .ReturnsAsync(student);

            // Act
            var result = await _controller.UpdateStudentAsync(student);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnStudent = Assert.IsType<Student>(okResult.Value);
            Assert.Equal("Updated John", returnStudent.Firstname);
        }
    }
}

