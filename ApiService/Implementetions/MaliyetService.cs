using ApiService.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Implementetions
{
    public class MaliyetService:IMaliyetService
    {
        private readonly IApiService _apiService;
        public MaliyetService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public string GetMaliyetUnsur()
        {
            return _apiService.Get($"GetMaliyetUnsur");
        }
        public string GetMaliyetTespitKanal()
        {
            return _apiService.Get($"GetMaliyetTespitKanal");
        }
    }
}
