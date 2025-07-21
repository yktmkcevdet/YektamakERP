using ApiService.Converters;
using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;

namespace ApiService.Implementetions
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
                Converters = new List<JsonConverter>
                {
                    new MultiFormatDateTimeConverter()
                }
            };
        }

        public async Task<string> PostAsync<T>(T entity, string apiAdres) where T : class
        {
            try
            {
                // Tek serileştirme yeterli
                string jsonContent = JsonConvert.SerializeObject(entity, _jsonSerializerSettings);
                byte[] data = Encoding.UTF8.GetBytes(jsonContent);
                jsonContent = JsonConvert.SerializeObject(data, _jsonSerializerSettings);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"/api/{apiAdres}", content);

                // HTTP status kontrolü
                if (!response.IsSuccessStatusCode)
                {
                    return "0"; 
                }

                string result = await response.Content.ReadAsStringAsync();
                // Daha güvenilir hata kontrolü
                if (string.IsNullOrWhiteSpace(result) ||
                    result.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    return "0";
                }

                return result;
            }
            catch (Exception ex)
            {
                // Log exception
                return "0";
            }
        }

        public string Post<T>(T entity, string apiAdres) where T : class
        {
            string postString = JsonConvert.SerializeObject(entity, _jsonSerializerSettings);
            byte[] data = Encoding.UTF8.GetBytes(postString);
            postString = JsonConvert.SerializeObject(data, _jsonSerializerSettings);
            var content = new StringContent(postString, Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync($"/api/{apiAdres}", content);
            //response.EnsureSuccessStatusCode();
            string result = response.Result.Content.ReadAsStringAsync().Result;
            if (result.Contains("error", StringComparison.OrdinalIgnoreCase)) return "0";
            return result;
        }

        public async Task<string> GetAsync(string apiAdres)
        {
            var response = await _httpClient.GetAsync($"/api/{apiAdres}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
        public string Get(string apiAdres)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/{apiAdres}");
            var response = _httpClient.Send(request);

            return response.Content.ReadAsStringAsync().Result;
        }

        public async Task<string> DeleteAsync(string apiAdres)
        {
            var response = await _httpClient.DeleteAsync($"/api/{apiAdres}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
