using Models;
using Models.DTO;

namespace ApiService.Interfaces
{
    public interface IAnaVeriService
    {
        public Task<string> SaveMaliyetUnsur(MaliyetUnsur maliyetUnsur);
        public Task<string> SaveMaliyetTespitKanal(MaliyetTespitKanal maliyetTespitKanal);
        public string GetMaliyetUnsur();
        public string GetMaliyetTespitKanal();
        public string GetDosyaTip();
        public string GetDosyalamaYapisi(DosyalamaYapisi dosyalamaYapisi);
        public string SaveDosyalamaYapisi(DosyalamaYapisi dosyalamaYapisi);
        public string DeleteDosyalamaYapisi(DosyalamaYapisi dosyalamaYapisi);
        public Task<string> SaveExcelForm(ExcelForm excelForm);
        public Task<string> GetExcelForm(ExcelForm excelForm);
        public string GetTalepNeden();
        public string GetBoyut();
        public string GetKdv();
    }
}
