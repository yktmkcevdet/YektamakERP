using ApiService.Interfaces;
using Models;

namespace ApiService.Implementetions
{
    public class SatinalmaTeklifService:ISatinalmaTeklifService
    {
        private readonly IApiService _apiService;
        public SatinalmaTeklifService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<string> DeleteSatinalmaTeklif(SatinalmaTeklifBaslik satinalmaTeklifBaslik)
        {
            return await _apiService.PostAsync(satinalmaTeklifBaslik, "DeleteSatinalmaTeklif");
        }

        public async Task<string> GetSatinalmaTeklif(SatinalmaTeklifBaslik satinalmaTeklifBaslik)
        {
            return await _apiService.PostAsync(satinalmaTeklifBaslik, "GetSatinalmaTeklif");
        }

        public async Task<string> SaveSatinalmaTeklif(List<SatinalmaTeklifBaslik> satinalmaTeklifBasliks)
        {
            return await _apiService.PostAsync(satinalmaTeklifBasliks, "SaveSatinalmaTeklif");
        }
    }

}
