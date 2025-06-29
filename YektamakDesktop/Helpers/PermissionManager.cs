using ApiService.Interfaces;
using Models;
using Models.DTO;
using Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakDesktop.Helpers
{
    public class PermissionManager:IDisposable
    {
        private static IKullaniciYetkiService _kullaniciYetkiService;
        private static ICache _cache;
        private static IJsonConverter _jsonConverter;
        private static IDataTableMapper _dataTableMapper;
        public PermissionManager(IKullaniciYetkiService kullaniciYetkiService, ICache cache,IJsonConverter jsonConverter,IDataTableMapper dataTableMapper)
        {
            _kullaniciYetkiService = kullaniciYetkiService;
            _cache = cache;
            _jsonConverter = jsonConverter;
            _dataTableMapper = dataTableMapper;
        }
        public PermissionManager(){}
        
        
        private List<AlanYetkiDTO> _alanYetki;
        private async Task<List<AlanYetkiDTO>> roleColumns(AlanYetkiDTO alanYetki) 
        {
            if (_alanYetki == null)
            {
                alanYetki.kullaniciId=_cache.kullanici.Id;
                string alanYetkiJson = await _kullaniciYetkiService.GetAlanYetki(alanYetki);
                Result result = _jsonConverter.DeserializeToModelList<Result>(alanYetkiJson)[0];
                var yetkiList = JsonConvert.DeserializeObject<List<AlanYetki>>(result.result);
                _alanYetki = _dataTableMapper.MapToEntityList<AlanYetkiDTO>(Common.ConvertHelper.ToDataTable(yetkiList));
                //string alanYetkiJson = await _kullaniciYetkiService.GetAlanYetki(alanYetki);
                //_alanYetki = _jsonConverter.DeserializeToModelList<AlanYetki>(alanYetkiJson);
            }
            return _alanYetki;
        }
        public async Task<bool> HasAccess(Kullanici kullanici, AlanYetkiDTO prop)
        {
            var filteredYetki = (await roleColumns(prop)).Where(p => p.formAd == prop.formAd && p.alanAd == prop.alanAd);
            return filteredYetki.Any();
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}