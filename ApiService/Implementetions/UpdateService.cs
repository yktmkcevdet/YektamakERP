using ApiService.Implementations;
using ApiService.Interfaces;

namespace ApiService.Implementations
{
    public class UpdateService : IUpdateService
    {
        private readonly IApiService _apiService;

        public UpdateService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public string CheckForUpdate()
        {
            return _apiService.Get($"version");
        }
    }
}
