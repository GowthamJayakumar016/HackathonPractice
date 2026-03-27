using StudentManagement.Shared.Models;
using StudentManagement.Shared.StudentRepository;
using System.Net.Http.Json;

namespace Studentmanagement.Client.Services
{
    public class TeacherService : ITeacherRepository
    {
        private readonly HttpClient _httpClient;
        public TeacherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Teacher> AddAsync(Teacher mod)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Teacher/Add-teacher", mod);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Teacher>();
            }

            return null;
        }

        public async Task<Teacher> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteFromJsonAsync<Teacher>(
                $"api/Teacher/Delete-teacher/{id}");

            return response;
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            var allteacher = await _httpClient.GetAsync("api/Teacher/All");
            var response = await allteacher.Content.ReadFromJsonAsync<List<Teacher>>();
            return response;
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            var single = await _httpClient.GetAsync($"api/Teacher/single-teacher/{id}");
            var response = await single.Content.ReadFromJsonAsync<Teacher>();
            return response;
        }

        public async Task<Teacher> UpdateAsync(Teacher mod)
        {
            var newjoined = await _httpClient.PutAsJsonAsync("api/Parent/Update-teacher", mod);
            var response = await newjoined.Content.ReadFromJsonAsync<Teacher>();
            return response;
        }
    }
}
