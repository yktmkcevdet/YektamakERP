using ApiService.Common;
using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiService.Implementetions
{
    public class SatinalmaService : ISatinalmaService
    {
        private readonly IApiService _apiService;

        public SatinalmaService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<string> DeleteSatinalmaTalep(SatinalmaTalep satinalmaTalepBaslik)
        {
            return await _apiService.PostAsync(satinalmaTalepBaslik, "DeleteSatinalmaTalep");
        }

        public async Task<string> GetFilteredSatinalmaSiparis(SatinalmaSiparis satinalmaSiparis)
        {
            return await _apiService.PostAsync(satinalmaSiparis, "GetFilteredSatinalmaSiparis");
        }

        public async Task<string> GetFilteredSatinalmaTalepDetay(SatinalmaTalepDetay satinalmaTalepDetay)
        {
            return await _apiService.PostAsync(satinalmaTalepDetay, "GetFilteredSatinalmaTalepDetay");
        }

        public async Task<string> GetSatinalmaTalep(SatinalmaTalep satinalmaTalepBaslik)
        {
            return await _apiService.PostAsync(satinalmaTalepBaslik, "GetSatinalmaTalep");
        }
        public string GetSatinalmaTalepSatirDetay(SatinalmaTalepDetay satinalmaTalepDetay)
        {
            return _apiService.Post(satinalmaTalepDetay, "GetSatinalmaTalepSatirDetay");
        }

        public async Task<string> GetTalepTipleri()
        {
            return await _apiService.GetAsync("GetTalepTipleri");
        }

        public async Task<string> SaveSatinalmaTalep(SatinalmaTalep satinalmaTalepBaslik)
        {
            var response = await _apiService.PostAsync(satinalmaTalepBaslik,"SaveSatinalmaTalep");
            return response;
        }

        public async Task<string> SaveSatinalmaTeklifTalep(List<SatinalmaTalepDetay> satinalmaTalepDetayList)
        {
            return await _apiService.PostAsync(satinalmaTalepDetayList, "SaveSatinalmaTeklifTalep");
        }

        
    }
}
