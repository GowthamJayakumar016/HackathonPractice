using Studentmanagement.Models;
using StudentManagement.Shared.Models;
using StudentManagement.Shared.StudentRepository;
using System.Net.Http.Json;

namespace Studentmanagement.Client.Services
{
    public class CountryService : ICountryRepository
    {
        private readonly HttpClient _httpClient; 
        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async  Task<Country?> AddAsync(Country mod)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Countries/Add-Countries", mod);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Country>();
            }

            return null;
        }

        public async Task<Country> DeleteAsync(int Id)
        {
            var response = await _httpClient.DeleteFromJsonAsync<Country>(
                $"api/Countries/Delete-Countries/{Id}");

            return response;
        }

        public async Task<List<Country>> GetAsync()
        {
            var allcountries = await _httpClient.GetAsync("api/Countries/All-Country");
            var response = await allcountries.Content.ReadFromJsonAsync<List<Country>>();
            return response;
        }

        public async Task<Country> GetByIdAsync(int Id)
        {
            var singlecountry = await _httpClient.GetAsync($"api/Countries/single-Country/{Id}");
            var response = await singlecountry.Content.ReadFromJsonAsync<Country>();
            return response;
        }

        public async Task<Country> UpdateAsync(Country mod)
        {
            var newcountry = await _httpClient.PutAsJsonAsync("api/Countries/Update-Country", mod);
            var response = await newcountry.Content.ReadFromJsonAsync<Country>();
            return response;
        }
    }
}
