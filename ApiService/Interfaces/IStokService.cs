using Models;

namespace ApiService.Interfaces
{
    public interface IStokService
    {
        public Task<string> GetStokKartAsync(StokKart stokKart=null);
        public string GetStokKart(StokKart stokKart = null);
        public Task<string> GetStokKartPdf(StokKart stokKart);
        public string GetStokGrup(StokGrup stokGrup);
        public string SaveStokGrup(StokGrup stokGrup);
        public string DeleteStokGrup(StokGrup stokGrup);
        public string GetMalzemeGrup(MalzemeGrup malzemeGrup);
        public string SaveMalzemeGrup(MalzemeGrup malzemeGrup);
        public string DeleteMalzemeGrup(MalzemeGrup malzemeGrup);
        public string GetMalzemeAltGrup(MalzemeAltGrup malzemeAltGrup);
        public string SaveMalzemeAltGrup(MalzemeAltGrup malzemeAltGrup);
        public string DeleteMalzemeAltGrup(MalzemeAltGrup malzemeAltGrup);
        public string GetMalzemeAltGrup2(MalzemeAltGrup2 malzemeAltGrup2);
        public string SaveMalzemeAltGrup2(MalzemeAltGrup2 malzemeAltGrup2);
        public string DeleteMalzemeAltGrup2(MalzemeAltGrup2 malzemeAltGrup2);
        public Task<string> GetMalzemeAltGrup2Async(MalzemeAltGrup2 malzemeAltGrup2);
        public string GetStokTip(StokTip stokTip);
        public string GetProfilTip(ProfilTip profilTip);
        public string GetOlcuBirim(OlcuBirim olcuBirim);
        public string GetMalzeme(Malzeme malzeme=null);
        public string GetMalzemeStandart(MalzemeStandart malzemeStandart);
        public Task<string> SaveStokKart(StokKart stokKart);
        public Task<string> SaveProjeStokKart(ProjeStokKart projeStokKart);
        public Task<string> SaveStokKartHammadde(StokKart stokKart);
        public Task<string> GetStokGrupKriter();
        public string GetExcelGrupParametre(ExcelGrupParametre excelGrupParametre);
        public string SaveExcelGrupParametre(ExcelGrupParametre excelGrupParametre);
        public string DeleteExcelGrupParametre(ExcelGrupParametre excelGrupParametre);
        public Task<string> DeleteStokKart(StokKart stokKart);
        public Task<string> DeleteStokKartDosya(StokKartDosya stokKartDosya);

    }
}
