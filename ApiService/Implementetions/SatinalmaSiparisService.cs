using ApiService.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Implementetions
{
    public class SatinalmaSiparisService : ISatinalmaSiparisService
    {
        private readonly IApiService _apiService;

        public SatinalmaSiparisService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<string> GetSatinalmaSiparisAsync(SatinalmaSiparis satinalmaSiparis)
        {
            return await _apiService.PostAsync(satinalmaSiparis, "GetSatinalmaSiparis");
        }

        public async Task<string> SaveSatinalmaSiparis(SatinalmaSiparis satinalmaSiparis)
        {
            return await _apiService.PostAsync(satinalmaSiparis, "SaveSatinalmaSiparis");
        }
    }
}
