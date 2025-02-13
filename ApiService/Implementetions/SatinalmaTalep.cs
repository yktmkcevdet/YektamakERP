using ApiService.Common;
using ApiService.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiService.Implementetions
{
    public class SatinalmaTalep : ISatinalmaTalep
    {
        private readonly IApiService _apiService;

        public SatinalmaTalep(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<string> SaveSatinalmaTalep(SatinalmaTalepBaslik satinalmaTalepBaslik)
        {
            var response = await _apiService.PostAsync(satinalmaTalepBaslik,"SaveSatinalmaTalep");
            return response;
        }
    }
}
