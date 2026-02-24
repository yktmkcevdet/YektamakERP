using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Implementations
{
    public class FirmaService : IFirmaService
    {
        private readonly IApiService _apiService;

        public FirmaService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public List<Firma> SaveFirma(Firma firma)
        {
            var jsonResult = _apiService.Post(firma, "SaveFirma");
            if (jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase) || string.IsNullOrEmpty(jsonResult))
            {
                throw new Exception(jsonResult);
            }
            else
            {
                return JsonConvert.DeserializeObject<List<Firma>>(jsonResult);
            }
        }
        public List<Firma> GetFirma(Firma firma)
        {
            var jsonResult = _apiService.Post(firma, "GetFirma");
            if (jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase) || string.IsNullOrEmpty(jsonResult))
            {
                return new List<Firma>();
            }
            else
            {
                return JsonConvert.DeserializeObject<List<Firma>>(jsonResult);
            }
        }

        public string GetSektor(Sektor sektor)
        {
            throw new NotImplementedException();
        }
        public List<Adres> GetAdres(Adres adres)
        {
            var jsonResult = _apiService.Post(adres,"GetAdres");
            var adresList = JsonConvert.DeserializeObject<List<Adres>>(jsonResult);
            return adresList;
        }
        public List<Adres> SaveAdres(Adres adres)
        {
            var jsonResult = _apiService.Post(adres, "SaveAdres");
            if(jsonResult.Contains("error",StringComparison.OrdinalIgnoreCase) || string.IsNullOrEmpty(jsonResult))
            {
                return new List<Adres>();
            }
            else
            {
                return JsonConvert.DeserializeObject<List<Adres>>(jsonResult);
            }
        }
        public string DeleteAdres(Adres adres)
        {
            return _apiService.Post(adres, "DeleteAdres");
        }
    }
}
