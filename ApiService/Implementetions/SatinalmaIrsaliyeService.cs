using ApiService.Interfaces;
using Models;
using Models.Models.Satinalma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Implementations
{
    public class SatinalmaIrsaliyeService: ISatinalmaIrsaliyeService
    {
        private readonly IApiService _apiService;

        public SatinalmaIrsaliyeService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<string> SaveSatinalmaIrsaliye(SatinalmaIrsaliyeBaslik satinalmaIrsaliyeBaslik)
        {
            return await _apiService.PostAsync(satinalmaIrsaliyeBaslik, "SaveSatinalmaIrsaliye");
        }
    }
}
