using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace YektamakDesktop.Helpers
{
    public static class LogoHelper
    {
        public static string clientSecret = "REFUQU1FUjptNVFQWDJIZjE3Sm1NaXVVMC93NlBnR1FlQzE0MDBLbnZaZWk1V2J6UGF3PQ=="; // Logo Client ID
        public static async Task<string> GetAccessTokenAsync(string url,  string userName, string password, string firmNr)
        {
            using (var http = new HttpClient())
            {
                // Authorization: Basic clientId:clientSecret
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", clientSecret);

                // form-data (x-www-form-urlencoded)
                var formData = new Dictionary<string, string>
                {
                    { "grant_type", "password" },
                    { "username", HttpUtility.UrlEncode(userName) },
                    { "firmno", firmNr },
                    { "password", HttpUtility.UrlEncode(password) }
                };

                var content = new FormUrlEncodedContent(formData);

                HttpResponseMessage response = await http.PostAsync(url, content);

                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();

                dynamic j = JsonConvert.DeserializeObject(json);

                return j.access_token;
            }
        }
        private static readonly HttpClient _httpClient = new HttpClient();

        private static void SetAuthorization(string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);
        }

        public static async Task<string> HttpPostAsync(string url, string param, string accessToken)
        {
            try
            {
                SetAuthorization(accessToken);

                var content = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);

                string result = await response.Content.ReadAsStringAsync();

                return result;
            }
            catch (HttpRequestException ex)
            {
                return ex.Message;
            }
        }

        public static async Task<string> HttpPutAsync(string url, string param, string accessToken)
        {
            try
            {
                SetAuthorization(accessToken);

                var content = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(url, content);

                string result = await response.Content.ReadAsStringAsync();

                return result;
            }
            catch (HttpRequestException ex)
            {
                return ex.Message;
            }
        }

        public static async Task<string> HttpPatchAsync(string url, string param, string accessToken)
        {
            try
            {
                SetAuthorization(accessToken);

                var content = new StringContent(param, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(new HttpMethod("PATCH"), url)
                {
                    Content = content
                };

                var response = await _httpClient.SendAsync(request);

                string result = await response.Content.ReadAsStringAsync();

                return result;
            }
            catch (HttpRequestException ex)
            {
                return ex.Message;
            }
        }

        public static async Task<string> HttpGetAsync(string url, string accessToken)
        {
            try
            {
                SetAuthorization(accessToken);

                var response = await _httpClient.GetAsync(url);

                string result = await response.Content.ReadAsStringAsync();

                return result;
            }
            catch (HttpRequestException ex)
            {
                return ex.Message;
            }
        }
    }
}

