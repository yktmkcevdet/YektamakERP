using ApiService.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Implementetions
{
    public class FirmaService : IFirmaService
    {
        private readonly IApiService _apiService;

        public FirmaService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public string GetFirma(Firma firma)
        {
            return _apiService.Get("GetFirma");
        }

        public string GetSektor(Sektor sektor)
        {
            throw new NotImplementedException();
        }
    }
}
