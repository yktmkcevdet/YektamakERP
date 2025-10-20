using ApiService.Interfaces;
using Models;

namespace ApiService.Implementetions
{
    public class ProjeService : IProjeService
    {
        private readonly IApiService _apiService;
        public ProjeService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<string> DeleteProjeDosya(Proje proje)
        {
            return await _apiService.PostAsync(proje, $"DeleteProjeDosya");
        }

        public string GetAllAssignedProjeKod()
        {
            return _apiService.Get($"GetAllAssignedProjeKod");
        }

        public string GetMarka()
        {
            return _apiService.Get($"GetMarka");
        }

        public string GetMarkaAltGrup()
        {
            return _apiService.Get($"GetMarkaAltGrup");
        }
        public string GetMarkaAltGrupKategori()
        {
            return _apiService.Get($"GetMarkaAltGrupKategori");
        }
        public string GetProje(Proje proje)
        {
            return _apiService.Post(proje, $"GetProje");
        }
        public async Task<string> GetProjeSorumlu(ProjeSorumlu projeSorumlu)
        {
            return await _apiService.PostAsync(projeSorumlu, $"GetProjeSorumlu");
        }
        public async Task<string> SaveProjeSorumlu(ProjeSorumlu projeSorumlu)
        {
            return await _apiService.PostAsync(projeSorumlu, $"SaveProjeSorumlu");
        }
        public string GetProjeTip()
        {
            return _apiService.Get($"GetProjeTip");
        }
        public async Task<string> GetProjeStokKart(ProjeStokKart projeStokKart)
        {
            return await _apiService.PostAsync(projeStokKart, $"GetProjeStokKart");
        }

        public async Task<string> SaveProjeStokKart(ProjeStokKart projeStokKart)
        {
            return await _apiService.PostAsync(projeStokKart, $"SaveProjeStokKart");
        }
        public async Task<string> DeleteProjeStokKart(ProjeStokKart projeStokKart)
        {
            return await _apiService.PostAsync(projeStokKart, $"DeleteProjeStokKart");
        }
        public string SaveProje(Proje proje)
        {
            return _apiService.Post(proje, $"SaveProje");
        }
        public string DeleteProje(Proje proje)
        {
            return _apiService.Post(proje, $"DeleteProje");
        }
        public async Task<string> GetProjeBomList(ProjeBom projeBomList)
        {
            return await _apiService.PostAsync(projeBomList, $"GetProjeBomList");
        }
    }
}
