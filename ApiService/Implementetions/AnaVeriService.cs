using ApiService.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Implementetions
{
    public class AnaVeriService : IAnaVeriService
    {
        private readonly IApiService _apiService;

        public AnaVeriService(IApiService apiService)
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
        public async Task<string> SaveMaliyetUnsur(MaliyetUnsur maliyetUnsur)
        {
            return await _apiService.PostAsync(maliyetUnsur, "SaveMaliyetUnsur");
        }

        public async Task<string> SaveMaliyetTespitKanal(MaliyetTespitKanal maliyetTespitKanal)
        {
            return await _apiService.PostAsync(maliyetTespitKanal, "SaveMaliyetTespitKanal");
        }
        public string GetDosyaTip()
        {
            return _apiService.Get($"GetDosyaTip");
        }
    }
}
