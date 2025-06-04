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

        public string GetAnaMenu(AnaMenu anaMenu)
        {
            return _apiService.Post(anaMenu, "GetAnaMenu");
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

        public string GetYetki(Yetki yetki)
        {
            return _apiService.Post(yetki, "GetYetki");
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
    }
}
