using ApiService.Common;
using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using System.Data;

namespace ApiService.Implementations
{
    public class UserService : IUserService
    {
        private readonly IApiService _apiService;

        public UserService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<Kullanici> GetKullaniciAsync(string username)
        {
            var jsonResult = await _apiService.GetAsync($"GetKullanici/{username}");
            if (string.IsNullOrEmpty(jsonResult)) return null;
            return JsonConvert.DeserializeObject<List<Kullanici>>(jsonResult).FirstOrDefault();
        }
    }
}
