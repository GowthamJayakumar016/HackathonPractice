using StudentManagement.Shared.Models;
using StudentManagement.Shared.StudentRepository;
using System.Net.Http.Json;

namespace Studentmanagement.Client.Services
{
    public class SystemCodeService : ISystemCodeRepository
    {
        private readonly HttpClient _httpClient;
        public SystemCodeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async  Task<SystemCode?> AddAsync(SystemCode mod)
        {
            var response = await _httpClient.PostAsJsonAsync("api/SystemCodes/Add-SystemCode", mod);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<SystemCode>();
            }

            return null;
        }

        public async Task<SystemCode> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteFromJsonAsync<SystemCode>(
                $"api/SystemCodes/Delete-SystemCode/{id}");

            return response;
        }

        public async  Task<List<SystemCode>> GetAllAsync()
        {
            var allcode = await _httpClient.GetAsync("api/SystemCodes/All-Systemcode");
            var response = await allcode.Content.ReadFromJsonAsync<List<SystemCode>>();
            return response;
        }

        public async Task<SystemCode> GetByIdAsync(int id)
        {
            var singlecode = await _httpClient.GetAsync($"api/SystemCodes/Single-Systemcode/{id}");
            var response = await singlecode.Content.ReadFromJsonAsync<SystemCode>();
            return response;
        }

        public async Task<SystemCode> UpdateAsync(SystemCode mod)
        {
            var newcountry = await _httpClient.PutAsJsonAsync("api/SystemCodes/Update-SystemCode", mod);
            var response = await newcountry.Content.ReadFromJsonAsync<SystemCode>();
            return response;
        }
    }
}
