using ApiService.Interfaces;
using Models;

namespace ApiService.Implementetions
{
    public class SatinalmaTalepService : ISatinalmaTalepService
    {
        private readonly IApiService _apiService;

        public SatinalmaTalepService(IApiService apiService)
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
        public async Task<string> GetSatinalmaTalepDetay(SatinalmaTalepDetay satinalmaTalepDetay=null)
        {
            return await _apiService.PostAsync(satinalmaTalepDetay, "GetSatinalmaTalepDetay");
        }
        public string GetSatinalmaTalepSatirDetay(SatinalmaTalepSatirDetay satinalmaTalepSatirDetay)
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
