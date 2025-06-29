using ApiService.Interfaces;
using Models;

namespace ApiService.Implementetions
{
    public class VadeService : IVadeService
    {
        private readonly IApiService _apiService;

        public VadeService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public string GetVade()
        {
            return _apiService.Get($"GetVade");
        }
        
    }
}
