using ApiService.Interfaces;
using Models;
using Models.DTO;

namespace ApiService.Implementations
{
    public class AnaVeriService : IAnaVeriService
    {
        private readonly IApiService _apiService;

        public AnaVeriService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public string GetMaliyetUnsur()
        {
            return _apiService.Get($"GetMaliyetUnsur");
        }
        public string GetMaliyetTespitKanal()
        {
            return _apiService.Get($"GetMaliyetTespitKanal");
        }
        public async Task<string> SaveMaliyetUnsur(MaliyetUnsur maliyetUnsur)
        {
            return await _apiService.PostAsync(maliyetUnsur, "SaveMaliyetUnsur");
        }

        public async Task<string> SaveMaliyetTespitKanal(MaliyetTespitKanal maliyetTespitKanal)
        {
            return await _apiService.PostAsync(maliyetTespitKanal, "SaveMaliyetTespitKanal");
        }
        public string GetDosyaTip()
        {
            return _apiService.Get($"GetDosyaTip");
        }
        public string GetDosyalamaYapisi(DosyalamaYapisi dosyalamaYapisi)
        {
            return _apiService.Post(dosyalamaYapisi,$"GetDosyalamaYapisi");
        }
        public string SaveDosyalamaYapisi(DosyalamaYapisi dosyalamaYapisi)
        {
            return _apiService.Post(dosyalamaYapisi,$"SaveDosyalamaYapisi");
        }
        public string DeleteDosyalamaYapisi(DosyalamaYapisi dosyalamaYapisi)
        {
            return _apiService.Post(dosyalamaYapisi,$"DeleteDosyalamaYapisi");
        }
        public async Task<string> SaveExcelForm(ExcelForm excelForm)
        {
            return await _apiService.PostAsync(excelForm, "SaveExcelForm");
        }
        public async Task<string> GetExcelForm(ExcelForm excelForm)
        {
            try
            {
                return await _apiService.PostAsync(excelForm, "GetExcelForm");
            }
            catch (Exception ex)
            {
                throw new Exception($"Excel formu alınırken hata oluştu: {ex.Message}");
            }
        }

        public string GetTalepNeden()
        {
            return _apiService.Get("GetTalepNeden");
        }
        public string SaveBoyut(Boyut boyut)
        {
            return _apiService.Post(boyut,"SaveBoyut");
        }
        public string GetBoyut()
        {
            return _apiService.Get("GetBoyut");
        }
        public string GetKdv()
        {
            return _apiService.Get("GetKdv");
        }
    }
}
