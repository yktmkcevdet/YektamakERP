using ApiService.Interfaces;
using Models;
using Models.DTO;
using Models.Models;
using Newtonsoft.Json;
using NPOI.OpenXmlFormats.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Interfaces;
using YektamakDesktop.Common;

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
        private async Task<List<AlanYetkiDTO>> roleColumns(AlanYetki alanYetki) 
        {
            if (_alanYetki == null)
            {
                _alanYetki = new();
                string alanYetkiJson = await _kullaniciYetkiService.GetAlanYetki(alanYetki);
                Result result = _jsonConverter.DeserializeToModelList<Result>(alanYetkiJson)[0];
                var yetkiList = _jsonConverter.ToModelList<AlanYetki>(result.result);
                foreach(var yetki in yetkiList)
                {
                    _alanYetki.Add(ConvertHelper.ToDTO<AlanYetkiDTO>(yetki));
                }
            }
            return _alanYetki;
        }
        public async Task<bool> HasAccess(AlanYetki prop)
        {
            var filteredYetki = (await roleColumns(prop)).Where(p => p.formAd == prop.formAd && p.alanAd == prop.alanAd && p.kullaniciId==prop.kullanici.Id && p.yetki);
            return filteredYetki.Any();
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}