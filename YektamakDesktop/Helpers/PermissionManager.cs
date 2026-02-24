using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
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
        private readonly IKullaniciYetkiService _kullaniciYetkiService;
        private readonly IConvertHelper _convertHelper;
        public PermissionManager(IKullaniciYetkiService kullaniciYetkiService, IConvertHelper convertHelper)
        {
            _kullaniciYetkiService = kullaniciYetkiService;
            _convertHelper = convertHelper;
        }
        public PermissionManager(){}
        
        
        private List<AlanYetkiDTO> _alanYetki;
        private async Task<List<AlanYetkiDTO>> roleColumns(AlanYetki alanYetki) 
        {
            if (_alanYetki == null)
            {
                _alanYetki = new();
                string alanYetkiJson = await _kullaniciYetkiService.GetAlanYetki(alanYetki);
                var yetkiList = JsonConvert.DeserializeObject<List<AlanYetki>>(alanYetkiJson);
                foreach(var yetki in yetkiList)
                {
                    _alanYetki.Add(_convertHelper.ToDTO<AlanYetkiDTO>(yetki));
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