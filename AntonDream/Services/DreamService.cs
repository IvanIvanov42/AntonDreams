using AntonDream.Models;
using AntonDream.Services.IServices;

namespace AntonDream.Services
{
    public class DreamService : IDreamService
    {
        private readonly HttpClient _httpClient;
        public DreamService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Dream>> GetDreamsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Dream>>("api/dream");
        }

        public async Task<Dream> GetDreamAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Dream>($"api/dream/{id}");
        }

        public async Task<Dream?> GetLatestDreamAsync()
        {
            var response = await _httpClient.GetAsync("api/dream/latest");
            if (response.IsSuccessStatusCode && response.Content.Headers.ContentLength > 0)
            {
                return await response.Content.ReadFromJsonAsync<Dream>();
            }
            else
            {
                return null;
            }
        }



        public async Task<Dream> PostDreamAsync(Dream newDream)
        {
            var response = await _httpClient.PostAsJsonAsync("api/dream", newDream);
            return await response.Content.ReadFromJsonAsync<Dream>();
        }
    }

}
