using ApiService.Interfaces;
using Models;

namespace ApiService.Implementetions
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
        public string GetBoyut()
        {
            return _apiService.Get("GetBoyut");
        }
    }
}
