using Models;
using Models.DTO;

namespace ApiService.Interfaces
{
    public interface IKullaniciYetkiService
    {
        public string GetAnaMenu(AnaMenu anaMenu);
        public string GetMenu(Menu menu=null);
        public string GetYetki(Yetki yetki); 
        public string GetKullanici(Kullanici kullanici);
        public string GetKullanici(string kullanici);
        public string SaveKullanici(Kullanici kullanici);
        public Task<string> DeleteMenu(Menu menu);
        public Task<string> DeleteEkran(Ekran ekran);
        public Task<string> SaveEkran(Ekran ekran);
        public Task<string> SaveMenu(Menu menu);
        public string GetKullaniciYetki(Kullanici kullanici);
        public Task<string> SaveYetki(Yetki yetki);
    }
}
