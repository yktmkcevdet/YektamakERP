using ApiService.Common;
using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using System.Data;

namespace ApiService.Implementations
{
    public class StokService : IStokService
    {
        private readonly IApiService _apiService;

        public StokService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public string GetMalzeme(Malzeme malzeme = null)
        {
            return _apiService.Post(malzeme, "GetMalzeme");
        }
        public string GetStokGrup(StokGrup stokGrup)
        {
            return _apiService.Post(stokGrup, "GetStokGrup");
        }
        public string SaveStokGrup(StokGrup stokGrup)
        {
            return _apiService.Post(stokGrup, "SaveStokGrup");
        }
        public string DeleteStokGrup(StokGrup stokGrup)
        {
            return _apiService.Post(stokGrup, "DeleteStokGrup");
        }
        public string GetMalzemeGrup(MalzemeGrup malzemeGrup)
        {
            return _apiService.Post(malzemeGrup, "GetMalzemeGrup");
        }
        public string SaveMalzemeGrup(MalzemeGrup malzemeGrup)
        {
            return _apiService.Post(malzemeGrup, "SaveMalzemeGrup");
        }
        public string DeleteMalzemeGrup(MalzemeGrup malzemeGrup)
        {
            return _apiService.Post(malzemeGrup, "DeleteMalzemeGrup");
        }
        public string GetMalzemeAltGrup(MalzemeAltGrup malzemeAltGrup)
        {
            return _apiService.Post(malzemeAltGrup, "GetMalzemeAltGrup");
        }
        public string SaveMalzemeAltGrup(MalzemeAltGrup malzemeAltGrup)
        {
            return _apiService.Post(malzemeAltGrup, "SaveMalzemeAltGrup");
        }
        public string DeleteMalzemeAltGrup(MalzemeAltGrup malzemeAltGrup)
        {
            return _apiService.Post(malzemeAltGrup, "DeleteMalzemeAltGrup");
        }
        public string GetMalzemeAltGrup2(MalzemeAltGrup2 malzemeAltGrup2)
        {
            return _apiService.Post(malzemeAltGrup2, "GetMalzemeAltGrup2");
        }
        public string SaveMalzemeAltGrup2(MalzemeAltGrup2 malzemeAltGrup2)
        {
            return _apiService.Post(malzemeAltGrup2, "SaveMalzemeAltGrup2");
        }
        public string DeleteMalzemeAltGrup2(MalzemeAltGrup2 malzemeAltGrup2)
        {
            return _apiService.Post(malzemeAltGrup2, "DeleteMalzemeAltGrup2");
        }
        public async Task<string> GetMalzemeAltGrup2Async(MalzemeAltGrup2 malzemeAltGrup2)
        {
            return await _apiService.PostAsync(malzemeAltGrup2, "GetMalzemeAltGrup2");
        }
        public string GetMalzemeStandart(MalzemeStandart malzemeStandart)
        {
            return _apiService.Post(malzemeStandart, "GetMalzemeStandart");
        }
        public string GetOlcuBirim(OlcuBirim olcuBirim)
        {
            return _apiService.Post(olcuBirim, "GetOlcuBirim");
        }
        public string GetProfilTip(ProfilTip profilTip)
        {
            return _apiService.Post(profilTip, "GetProfilTip");
        }
        public async Task<string> GetStokKartAsync(StokKart stokKart)
        {
            return await _apiService.PostAsync(stokKart, "GetStokKart");
        }
        public List<StokKart> GetStokKart(StokKart stokKart)
        {
            var response = _apiService.Post(stokKart, $"GetStokKart/");
            if (response.Contains("error", StringComparison.OrdinalIgnoreCase) || string.IsNullOrEmpty(response))
            {
                throw new Exception(response);
            }
            else
            {
                return JsonConvert.DeserializeObject<List<StokKart>>(response);
            }
        }

        public List<StokKart> GetStokKartPdf(StokKart stokKart)
        {
            var jsonResult = _apiService.Post(stokKart, "GetStokKartPdf");
            if (jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase) || string.IsNullOrEmpty(jsonResult))
            {
                throw new Exception(jsonResult);
            }
            else
            {
                return JsonConvert.DeserializeObject<List<StokKart>>(jsonResult);
            }
        }

        public async Task<string> GetStokKartPdfAsync(ProjeStokKart stokKart)
        {
            return await _apiService.PostAsync(stokKart, $"GetStokKartPdf/");
        }

        public string GetStokTip(StokTip stokTip)
        {
            return _apiService.Post(stokTip, "GetStokTip");
        }

        public async Task<string> SaveStokKart(StokKart stokKart)
        {
            return await _apiService.PostAsync(stokKart, "SaveStokKart");
        }
        public async Task<string> DeleteStokKart(ProjeStokKart stokKart)
        {
            return await _apiService.PostAsync(stokKart, "DeleteStokKart");
        }
        public async Task<string> DeleteStokKartDosya(StokKartDosya stokKartDosya)
        {
            return await _apiService.PostAsync(stokKartDosya, "DeleteStokKartDosya");
        }
        public async Task<string> SaveStokKartHammadde(ProjeStokKart stokKart)
        {
            return await _apiService.PostAsync(stokKart, "SaveStokKartHammadde");
        }

        public async Task<string> GetStokGrupKriter()
        {
            return await _apiService.GetAsync("StokGrupKriter");
        }
        public string GetExcelGrupParametre(ExcelGrupParametre excelGrupParametre)
        {
            return _apiService.Post(excelGrupParametre,"GetExcelGrupParametre");
        }
        public string SaveExcelGrupParametre(ExcelGrupParametre excelGrupParametre)
        {
            return _apiService.Post(excelGrupParametre, "SaveExcelGrupParametre");
        }
        public string DeleteExcelGrupParametre(ExcelGrupParametre excelGrupParametre)
        {
            return _apiService.Post(excelGrupParametre, "DeleteExcelGrupParametre");
        }
        public async Task<string> SaveProjeStokKart(ProjeStokKart projeStokKart)
        {
            return await _apiService.PostAsync(projeStokKart, "SaveProjeStokKart");
        }
        public async Task<string> SaveStokKartDosya(StokKartDosya stokKartDosya)
        {
            return await _apiService.PostAsync(stokKartDosya, "SaveStokKartDosya");
        }
    }
}
