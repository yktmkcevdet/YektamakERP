using ApiService.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Implementations
{
    public class CariService : ICariService
    {
        private readonly IApiService _apiService;
        public CariService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public Task<string> GetCariHesapEkstresi(CariKart cariKart)
        {
            return _apiService.PostAsync(cariKart, "GetCariHesapEkstresi");
        }
    }
}
