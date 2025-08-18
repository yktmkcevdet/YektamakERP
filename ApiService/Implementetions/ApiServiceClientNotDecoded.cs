using ApiService.Converters;
using ApiService.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Implementetions
{
    internal class ApiServiceClientNotDecoded : IApiService
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private readonly HttpClient _httpClient;
        public ApiServiceClientNotDecoded(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromSeconds(200);
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Converters = new List<JsonConverter>
                {
                    new MultiFormatDateTimeConverter()
                }
            };
        }
        public async Task<string> DeleteAsync(string apiAdres)
        {
            var response = await _httpClient.DeleteAsync($"/api/{apiAdres}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public string Get(string apiAdres)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/{apiAdres}");
            var response = _httpClient.Send(request);

            return response.Content.ReadAsStringAsync().Result;
        }

        public async Task<string> GetAsync(string apiAdres)
        {
            var response = await _httpClient.GetAsync($"/api/{apiAdres}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public string Post<T>(T entity, string apiAdres) where T : class
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(entity,_jsonSerializerSettings);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response =  _httpClient.PostAsync($"/api/{apiAdres}", content);

                string result = response.Result.Content.ReadAsStringAsync().Result;


                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> PostAsync<T>(T entity, string apiAdres) where T : class
        {
            try
            {
                // Tek serileştirme yeterli
                string jsonContent = JsonConvert.SerializeObject(entity,Formatting.Indented,_jsonSerializerSettings);

                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PostAsync($"/api/{apiAdres}", content);

                // HTTP status kontrolü
                //if (!response.IsSuccessStatusCode)
                //{
                //    return "0";
                //}
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception ex)
            {
                // Log exception
                return "0";
            }
        }
    }
}
