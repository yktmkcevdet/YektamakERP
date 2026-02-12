using ApiService.Interfaces;
using Models;
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

        public async Task<List<SatinalmaIrsaliyeBaslik>> SaveSatinalmaIrsaliye(SatinalmaIrsaliyeBaslik satinalmaIrsaliyeBaslik)
        {
            var jsonSatinalmaIrsaliyeList = await _apiService.PostAsync(satinalmaIrsaliyeBaslik, "SaveSatinalmaIrsaliye");
            List<SatinalmaIrsaliyeBaslik> satinalmaIrsaliyeList = new List<SatinalmaIrsaliyeBaslik>();
            if (!string.IsNullOrEmpty(jsonSatinalmaIrsaliyeList) && !jsonSatinalmaIrsaliyeList.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                satinalmaIrsaliyeList = _jsonConverter.DeserializeObject<List<SatinalmaIrsaliyeBaslik>>(jsonSatinalmaIrsaliyeList);
            }
            else
            {
                throw new Exception(jsonSatinalmaIrsaliyeList);
            }
            return satinalmaIrsaliyeList;
        }
        public async Task<List<SatinalmaIrsaliyeBaslik>> GetSatinalmaIrsaliye(SatinalmaIrsaliyeBaslik satinalmaIrsaliyeBaslik)
        {
            string result = await _apiService.PostAsync(satinalmaIrsaliyeBaslik, "GetSatinalmaIrsaliye");
            return _jsonConverter.DeserializeObject<List<SatinalmaIrsaliyeBaslik>>(result);
        }
        public async Task<string> DeleteSatinalmaIrsaliye(SatinalmaIrsaliyeBaslik satinalmaIrsaliyeBaslik)
        {
            string result = await _apiService.PostAsync(satinalmaIrsaliyeBaslik, "DeleteSatinalmaIrsaliye");
            return result;
        }
    }
}
