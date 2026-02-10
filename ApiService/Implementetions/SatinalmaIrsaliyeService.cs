using ApiService.Interfaces;
using Models;
using Models.Models.Satinalma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Interfaces;

namespace ApiService.Implementations
{
    public class SatinalmaIrsaliyeService: ISatinalmaIrsaliyeService
    {
        private readonly IApiService _apiService;
        private readonly IJsonConverter _jsonConverter;

        public SatinalmaIrsaliyeService(IApiService apiService, IJsonConverter jsonConverter)
        {
            _apiService = apiService;
            _jsonConverter = jsonConverter;
        }

        public async Task<string> SaveSatinalmaIrsaliye(SatinalmaIrsaliyeBaslik satinalmaIrsaliyeBaslik)
        {
            return await _apiService.PostAsync(satinalmaIrsaliyeBaslik, "SaveSatinalmaIrsaliye");
        }
        public async Task<List<SatinalmaIrsaliyeBaslik>> GetSatinalmaIrsaliye(SatinalmaIrsaliyeBaslik satinalmaIrsaliyeBaslik)
        {
            string result = await _apiService.PostAsync(satinalmaIrsaliyeBaslik, "GetSatinalmaIrsaliye");
            return _jsonConverter.DeserializeObject<List<SatinalmaIrsaliyeBaslik>>(result);
        }
    }
}
