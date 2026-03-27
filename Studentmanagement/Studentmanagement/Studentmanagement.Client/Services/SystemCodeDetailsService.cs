using StudentManagement.Shared.Models;
using StudentManagement.Shared.StudentRepository;
using System.Net.Http.Json;

namespace Studentmanagement.Client.Services
{
    public class SystemCodeDetailsService : ISystemCodeDetailsRepository
    {
        private readonly HttpClient _httpClient;
        public SystemCodeDetailsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<SystemCodeDetail?> AddAsync(SystemCodeDetail mod)
        {
            var response = await _httpClient.PostAsJsonAsync("api/SystemCodeDetails/Add-Countries", mod);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<SystemCodeDetail>();
            }

            return null;
        }

        public async Task<SystemCodeDetail> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteFromJsonAsync<SystemCodeDetail>(
                $"api/SystemCodeDetails/Delete/{id}");

            return response;
        }

        public async Task<List<SystemCodeDetail>> GetAllAsync()
        {
            var allco = await _httpClient.GetAsync("api/SystemCodeDetails/All");
            var response = await allco.Content.ReadFromJsonAsync<List<SystemCodeDetail>>();
            return response;
        }

        public async  Task<List<SystemCodeDetail>> GetByCodeAsync(string code)
        {
            var allcobycode = await _httpClient.GetAsync("api/SystemCodeDetails/AllByCode");
            var response = await allcobycode.Content.ReadFromJsonAsync<List<SystemCodeDetail>>();
            return response;
        }

        public async  Task<SystemCodeDetail> GetByIdAsync(int id)
        {
            var singlecode = await _httpClient.GetAsync($"api/SystemCodeDetails/Single/{id}");
            var response = await singlecode.Content.ReadFromJsonAsync<SystemCodeDetail>();
            return response;
        }

        public async Task<SystemCodeDetail> UpdateAsync(SystemCodeDetail mod)
        {
            var newcode = await _httpClient.PutAsJsonAsync("api/SystemCodeDetails/Update", mod);
            var response = await newcode.Content.ReadFromJsonAsync<SystemCodeDetail>();
            return response;
        }
    }
}
