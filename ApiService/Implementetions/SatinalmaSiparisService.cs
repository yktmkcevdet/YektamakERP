using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;

namespace ApiService.Implementations
{
    public class SatinalmaSiparisService : ISatinalmaSiparisService
    {
        private readonly IApiService _apiService;

        public SatinalmaSiparisService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<List<SatinalmaSiparis>> GetSatinalmaSiparisAsync(SatinalmaSiparis satinalmaSiparis)
        {
            var satinalmaSiparisList = await _apiService.PostAsync(satinalmaSiparis, "GetSatinalmaSiparis");
            return JsonConvert.DeserializeObject<List<SatinalmaSiparis>>(satinalmaSiparisList);
        }
        public async Task<List<SatinalmaSiparisDetay>> GetSatinalmaSiparisDetayAsync(SatinalmaSiparisDetay satinalmaSiparisDetay)
        {
            var satinalmaSiparisDetayList = await _apiService.PostAsync(satinalmaSiparisDetay, "GetSatinalmaSiparisDetay");
            return JsonConvert.DeserializeObject<List<SatinalmaSiparisDetay>>(satinalmaSiparisDetayList);
        }
        public async Task<string> SaveSatinalmaSiparis(SatinalmaSiparis satinalmaSiparis)
        {
            return await _apiService.PostAsync(satinalmaSiparis, "SaveSatinalmaSiparis");
        }
        public async Task<string> DeleteSatinalmaSiparis(SatinalmaSiparis satinalmaSiparis)
        {
            return await _apiService.PostAsync(satinalmaSiparis, "DeleteSatinalmaSiparis");
        }
    }
}
