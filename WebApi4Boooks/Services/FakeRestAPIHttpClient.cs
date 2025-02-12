using System.Text.Json;
using WebApi4Boooks.Models;
using WebApi4Boooks.Services.Interfaces;

namespace WebApi4Boooks.Services
{
    public class FakeRestAPIHttpClient : IFakeRestAPIHttpClient
    {
        private readonly HttpClient _httpClient;
        public FakeRestAPIHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Boook>> GetBoooks()
        {
            var response = await _httpClient.GetAsync("Books");
            response.EnsureSuccessStatusCode();
            
            var jsonString = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Boook> boooks = JsonSerializer.Deserialize<List<Boook>>(jsonString, options);

            return boooks ?? new List<Boook>();
        }

        public async Task<Boook> GetBoookById(int id)
        {

            var response = await _httpClient.GetAsync($"Books/{id}");
            response.EnsureSuccessStatusCode();
            
            var jsonString = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Boook boook = JsonSerializer.Deserialize<Boook>(jsonString, options);
            return boook;
        }
    }
}
