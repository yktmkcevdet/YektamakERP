using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using Utilities.Interfaces;

namespace ApiService.Implementations
{
    public class SatinalmaTalepService : ISatinalmaTalepService
    {
        private readonly IApiService _apiService;
        private readonly IJsonConverter _jsonConverter;

        public SatinalmaTalepService(IApiService apiService, IJsonConverter jsonConverter)
        {
            _jsonConverter = jsonConverter;
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

        public async Task<List<SatinalmaTalep>> GetSatinalmaTalep(SatinalmaTalep satinalmaTalepBaslik)
        {
            string jsonResult = await _apiService.PostAsync(satinalmaTalepBaslik, "GetSatinalmaTalep");
            if(jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Satınalma talebi getirilirken bir hata oluştu: " + jsonResult);
            }
            else if (string.IsNullOrEmpty(jsonResult)) 
            {
                return new List<SatinalmaTalep>();
            }
            else
            {
                return _jsonConverter.DeserializeObject<List<SatinalmaTalep>>(jsonResult);
            }
        }
        public async Task<string> GetSatinalmaTalepDetay(SatinalmaTalepDetay satinalmaTalepDetay=null)
        {
            return await _apiService.PostAsync(satinalmaTalepDetay, "GetSatinalmaTalepDetay");
        }
        public string GetSatinalmaTalepSatirDetay(SatinalmaTalepSatirDetayDTO satinalmaTalepSatirDetay)
        {
            return _apiService.Post(satinalmaTalepSatirDetay, "GetSatinalmaTalepSatirDetay");
        }

        public async Task<string> GetTalepTipleri()
        {
            return await _apiService.GetAsync("GetTalepTipleri");
        }

        public async Task<string> SatinalmaTalepOnay(SatinalmaTalep satinalmaTalepBaslik)
        {
            var response = await _apiService.PostAsync(satinalmaTalepBaslik, "SatinalmaTalepOnay");
            return response;
        }

        public async Task<string> SaveSatinalmaTalep(SatinalmaTalep satinalmaTalepBaslik)
        {
            var response = await _apiService.PostAsync(satinalmaTalepBaslik, "SaveSatinalmaTalep");
            return response;
        }

        public async Task<string> SaveSatinalmaTeklifTalep(List<SatinalmaTalepDetay> satinalmaTalepDetayList)
        {
            return await _apiService.PostAsync(satinalmaTalepDetayList, "SaveSatinalmaTeklifTalep");
        }
    }
}
