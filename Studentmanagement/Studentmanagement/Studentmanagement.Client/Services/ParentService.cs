using StudentManagement.Shared.Models;
using StudentManagement.Shared.StudentRepository;
using System.Net.Http.Json;

namespace Studentmanagement.Client.Services
{
    public class ParentService : IParentRepository
    {
        private readonly HttpClient _httpClient;
        public ParentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Parent?> AddAsync(Parent mod)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Parent/Add-parent", mod);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Parent>();
            }

            return null;
        }

        public async  Task<Parent> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteFromJsonAsync<Parent>(
                $"api/Parent/Delete-Parent/{id}");

            return response;
        }

        public async Task<List<Parent>> GetAllAsync()
        {
            var allcountries = await _httpClient.GetAsync("api/Parent/All");
            var response = await allcountries.Content.ReadFromJsonAsync<List<Parent>>();
            return response;
        }

        public async  Task<Parent> GetByIdAsync(int id)
        {
            var single = await _httpClient.GetAsync($"api/parent/single-Parent/{id}");
            var response = await single.Content.ReadFromJsonAsync<Parent>();
            return response;
        }

        public async  Task<Parent> UpdateAsync(Parent mod)
        {
            var newparent = await _httpClient.PutAsJsonAsync("api/Parent/Update-parent", mod);
            var response = await newparent.Content.ReadFromJsonAsync<Parent>();
            return response;
        }
    }
}
