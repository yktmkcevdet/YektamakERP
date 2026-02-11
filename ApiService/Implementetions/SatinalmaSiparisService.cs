using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using Utilities.Interfaces;

namespace ApiService.Implementations
{
    public class SatinalmaSiparisService : ISatinalmaSiparisService
    {
        private readonly IApiService _apiService;
        private readonly IJsonConverter _jsonConverter;

        public SatinalmaSiparisService(IApiService apiService, IJsonConverter jsonConverter)
        {
            _apiService = apiService;
            _jsonConverter = jsonConverter;
        }
        public async Task<List<SatinalmaSiparis>> GetSatinalmaSiparisAsync(SatinalmaSiparis satinalmaSiparis)
        {
            var jsonSatinalmaSiparisList = await _apiService.PostAsync(satinalmaSiparis, "GetSatinalmaSiparis");
            List<SatinalmaSiparis> satinalmaSiparisList = new List<SatinalmaSiparis>();
            if (!string.IsNullOrEmpty(jsonSatinalmaSiparisList) && !jsonSatinalmaSiparisList.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                satinalmaSiparisList = _jsonConverter.DeserializeObject<List<SatinalmaSiparis>>(jsonSatinalmaSiparisList);
            }
            return satinalmaSiparisList;
        }
        public async Task<List<SatinalmaSiparisDetay>> GetSatinalmaSiparisDetayAsync(SatinalmaSiparisDetay satinalmaSiparisDetay)
        {
            var satinalmaSiparisDetayList = await _apiService.PostAsync(satinalmaSiparisDetay, "GetSatinalmaSiparisDetay");
            return _jsonConverter.DeserializeObject<List<SatinalmaSiparisDetay>>(satinalmaSiparisDetayList);
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
