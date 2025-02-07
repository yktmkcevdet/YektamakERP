using ApiService.Implementetions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;

namespace ApiService.Interfaces
{
    public class ApiServiceClient : IApiService
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private readonly HttpClient _httpClient;
        public ApiServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateFormatString = "yyyy-MM-dd HH:mm:ss",
                Converters = new JsonConverter[] { new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" } }
            };
        }

        public async Task<string> PostAsync<T>(T entity, string apiAdres) where T : class
        {
            string postString = JsonConvert.SerializeObject(entity, _jsonSerializerSettings);
            var content = new StringContent(postString, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"/api/{apiAdres}", content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAsync(string apiAdres)
        {
            var response = await _httpClient.GetAsync($"/api/{apiAdres}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> DeleteAsync<T>(T entity, string apiAdres) where T : class
        {
            string postString = JsonConvert.SerializeObject(entity, _jsonSerializerSettings);
            var content = new StringContent(postString, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"/api/{apiAdres}", content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
