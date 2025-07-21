using Models;

namespace ApiService.Interfaces
{
    public interface IStokService
    {
        public Task<string> GetStokKart(StokKart stokKart=null);
        public Task<string> GetStokKartPdf(StokKart stokKart);
        public string GetStokGrup(StokGrup stokGrup);
        public string GetMalzemeGrup(MalzemeGrup malzemeGrup);
        public string GetMalzemeAltGrup(MalzemeAltGrup malzemeAltGrup);
        public string GetMalzemeAltGrup2(MalzemeAltGrup2 malzemeAltGrup2);
        public Task<string> GetMalzemeAltGrup2Async(MalzemeAltGrup2 malzemeAltGrup2);
        public string GetStokTip(StokTip stokTip);
        public string GetProfilTip(ProfilTip profilTip);
        public string GetOlcuBirim(OlcuBirim olcuBirim);
        public string GetMalzeme(Malzeme malzeme=null);
        public string GetMalzemeStandart(MalzemeStandart malzemeStandart);
        public Task<string> SaveStokKart(StokKart stokKart);
        public Task<string> SaveStokKartHammadde(StokKart stokKart);
        public Task<string> GetStokGrupKriter();
        public string GetExcelGrupParametre();
        public Task<string> DeleteStokKart(StokKart stokKart);
        public Task<string> DeleteStokKartDosya(StokKartDosya stokKartDosya);

    }
}
