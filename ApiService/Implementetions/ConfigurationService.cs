using ApiService.Interfaces;
using Models;

namespace ApiService.Implementetions
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IApiService _apiService;
        public ConfigurationService(IApiService apiService)
        {
            _apiService = apiService;
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
