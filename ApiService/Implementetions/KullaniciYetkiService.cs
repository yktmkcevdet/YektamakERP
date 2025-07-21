using ApiService.Interfaces;
using Models;
using Models.DTO;

namespace ApiService.Implementetions
{
    public class KullaniciYetkiService : IKullaniciYetkiService
    {
        private readonly IApiService _apiService;
        public KullaniciYetkiService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<string> DeleteEkran(Ekran ekran)
        {
            return await _apiService.PostAsync(ekran,"DeleteEkran");
        }

        public async Task<string> DeleteMenu(Menu menu)
        {
            return await _apiService.PostAsync(menu,"DeleteMenu");
        }

        public async Task<string> GetAlanYetki(AlanYetkiDTO alanYetki)
        {
            return await _apiService.PostAsync(alanYetki, "GetAlanYetki");
        }
        public async Task<string> DeleteAlanYetki(AlanYetki alanYetki)
        {
            return await _apiService.PostAsync(alanYetki, "DeleteAlanYetki");
        }

        public string GetAnaMenu(AnaMenuDTO anaMenu)
        {
            return _apiService.Post(anaMenu, "GetAnaMenu");
        }

        public async Task<string> GetKullaniciAsync(Kullanici kullanici)
        {
            return await _apiService.PostAsync(kullanici, "GetKullanici");
        }
        public string GetKullanici(Kullanici kullanici)
        {
            return _apiService.Post(kullanici, "GetKullanici");
        }
        public string GetKullanici(string kullanici)
        {
            return _apiService.Get($"GetKullanici/{kullanici}");
        }

        public string GetKullaniciYetki(Kullanici kullanici)
        {
            return _apiService.Post(kullanici, "GetKullaniciYetki");
        }

        public string GetMenu(Menu menu)
        {
            return _apiService.Post(menu, "GetMenu");
        }

        public string GetRol(Rol rol)
        {
            return _apiService.Post(rol, "GetRol");
        }

        public string GetYetki(Yetki yetki)
        {
            return _apiService.Post(yetki, "GetYetki");
        }
        public string GetYetki(Rol rol)
        {
            return _apiService.Post(rol, "GetRol");
        }

        public async Task<string> SaveEkran(Ekran ekran)
        {
            return await _apiService.PostAsync(ekran, "SaveEkran");
        }

        public string SaveKullanici(Kullanici kullanici)
        {
            return _apiService.Post(kullanici, "SaveKullanici");
        }

        public async Task<string> SaveMenu(Menu menu)
        {
            return await _apiService.PostAsync(menu, "SaveMenu");
        }

        public async Task<string> SaveYetki(Yetki yetki)
        {
            return await _apiService.PostAsync(yetki, "SaveYetki");
        }
        public async Task<string> SaveAlanYetki(AlanYetkiDTO alanYetki)
        {
            return await _apiService.PostAsync(alanYetki, "SaveAlanYetki");
        }
    }
}
