using Studentmanagement.Models;
using StudentManagement.Shared.StudentRepository;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace Studentmanagement.Client.Services
{
    public class StudentService : IStudentRepository
    {
        private readonly HttpClient _httpClient;
        public StudentService(HttpClient httpClient)
        {
           _httpClient = httpClient;
        }

        public async Task<Student?> AddStudentAsync(Student stud)
        {
            var response = await _httpClient.PostAsJsonAsync("api/student/Add-students", stud);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Student>();
            }

            return null;
        }

        public async Task<Student?> DeleteStudentAsync(int studentId)
        {
            var response = await _httpClient.DeleteFromJsonAsync<Student>(
                $"api/Student/Delete-student/{studentId}");

            return response;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            var allstudent = await _httpClient.GetAsync("api/Student/All-students");
            var response = await allstudent.Content.ReadFromJsonAsync<List<Student>>();
            return response;

        }

        public async Task<Student> GetStudentsByIdAsync(int studentId)
        {
            var singlestudent = await _httpClient.GetAsync("api/Student/single-student/{studentId}");
            var response = await singlestudent.Content.ReadFromJsonAsync<Student>();
            return response;
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            var newstudent = await _httpClient.PutAsJsonAsync("api/Student/Update-Student", student);
            var response = await newstudent.Content.ReadFromJsonAsync<Student>();
            return response;
        }
    }
}
