using ApiService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Implementetions
{
    public class DovizCinsiService:IDovizCinsiService
    {
        private readonly IApiService _apiService;
        public DovizCinsiService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public string GetDovizCinsi()
        {
            return _apiService.Get($"GetDovizCinsi");
        }
    }
}
