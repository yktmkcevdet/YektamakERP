using ApiService.Interfaces;
using Models.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ApiService.Common;
using Models;
using System.Data;

namespace ApiService.Implementetions
{
    public class SatisService : ISatisService
    {
        private readonly IApiService _apiService;

        public SatisService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<List<MondayTeklif>> GetMondayTeklif()
        {
            string apiKey = "eyJhbGciOiJIUzI1NiJ9.eyJ0aWQiOjQ3NTg1NjM5MCwiYWFpIjoxMSwidWlkIjo3MTg0NTE1NCwiaWFkIjoiMjAyNS0wMi0yMVQwNzo1MDowNi45MDVaIiwicGVyIjoibWU6d3JpdGUiLCJhY3RpZCI6Mjc4NjcxNjYsInJnbiI6ImV1YzEifQ.rpgjU3Lkh9HnJ7177PKaFQpA4l-yo2dq1e7cnCPA8Xo"; // Buraya Monday.com API anahtarınızı ekleyin
            string boardId = "1809456125"; // Buraya çekmek istediğiniz board’un ID’sini ekleyin
            string url = "https://api.monday.com/v2";

            // GraphQL sorgusu
            string query = @"
            {
                boards(ids: [" + boardId + @"]) { 
                    name
                    items_page {
                        items {
                            name
                            column_values {
                                id
                                text
                            }
                        }
                    }
                }
            }";
            List<MondayTeklif> mondayTeklifs = new List<MondayTeklif>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", apiKey);

                var requestBody = new { query };
                var request = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    JObject jsonResponse = JObject.Parse(responseBody);
                    JArray items = (JArray)jsonResponse["data"]["boards"][0]["items_page"]["items"];
                    foreach (var item in items)
                    {
                        MondayTeklif mondayTeklif = new MondayTeklif();

                        foreach (PropertyInfo fieldInfo in mondayTeklif.GetType().GetProperties())
                        {
                            var deneme = item["column_values"].ToList();
                            var deneme2 = deneme.FirstOrDefault(x => x["id"].ToString() == fieldInfo.Name);
                            var value = item["column_values"].ToList().FirstOrDefault(x => x["id"].ToString() == fieldInfo.Name)["text"];
                            Type type = typeof(DateTime);
                            string strValue = (fieldInfo.PropertyType == type) ? (value.ToString() == "" ? DateTime.MinValue : value).ToString() : value.ToString();
                            fieldInfo.SetValue(mondayTeklif, Convert.ChangeType(strValue, fieldInfo.PropertyType));
                        }
                        mondayTeklifs.Add(mondayTeklif);
                    }
                    return mondayTeklifs;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<string> SaveSatisSiparisTeklifTalep(string siparisTeklifTalep) 
        {
            return await _apiService.GetAsync($"savesatissiparistekliftalep/{siparisTeklifTalep}");
        }
        public async Task<string> DeleteSatisSiparisTeklifTalep(string siparisTeklifTalep)
        {
            return await _apiService.DeleteAsync($"DeleteSatisSiparisTeklifTalep/{siparisTeklifTalep}");
        }

        public string GetReferansKaynak()
        {
            return _apiService.Get("GetReferansKaynak");
        }

        public string GetSatisTeklifTalep(SatisTeklifTalep satisTeklifTalep)
        {
            return _apiService.Post(satisTeklifTalep, "GetSatisTeklifTalep");
        }
        public async Task<string> SaveSatisSiparisTeklifTalep(SatisTeklifTalep satisTeklifTalep)
        {
            return await _apiService.PostAsync(satisTeklifTalep, "SaveSatisSiparisTeklifTalep");
        }
    }
}