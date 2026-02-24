using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using System.Runtime.Intrinsics.X86;

namespace ApiService.Implementations
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IApiService _apiService;
        public ConfigurationService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<DosyalamaYapisi>> GetDosyalamaYapisi(DosyalamaYapisi dosyalamaYapisi)
        {
            var jsonResult = await _apiService.PostAsync(dosyalamaYapisi, "GetDosyalamaYapisi");
            if (jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase) || string.IsNullOrEmpty(jsonResult))
            {
                throw new Exception(jsonResult);
            }
            else
            {
                return JsonConvert.DeserializeObject<List<DosyalamaYapisi>>(jsonResult);
            }
        }

        public async Task<string> GetGridSettings(GridSettings gridSettings)
        {
            return await _apiService.PostAsync(gridSettings, "GetGridSettings");
        }

        public async Task<string> SaveGridSettings(GridSettings gridSettings)
        {
            return await _apiService.PostAsync(gridSettings, "SaveGridSettings");
        }
    }
}
