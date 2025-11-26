using Models;

namespace ApiService.Interfaces
{
    public interface IProjeService
    {
        public string GetProje(Proje proje);
        public Task<string> GetProjeSorumlu(ProjeSorumlu projeSorumlu);
        public Task<string> SaveProjeSorumlu(ProjeSorumlu projeSorumlu);
        public string GetProjeTip();
        public string GetMarka();
        public string GetMarkaAltGrup();
        public string GetMarkaAltGrupKategori();
        public string GetAllAssignedProjeKod();
        public Task<string> DeleteProjeDosya(Proje proje);
        public Task<string> SaveProjeStokKart(ProjeStokKart projeStokKart);
        public string SaveProje(Proje proje);
        public string DeleteProje(Proje proje);
        public string DeleteProjeFile(ProjeDosya projeDosya);
        public Task<string> DeleteProjeStokKart(ProjeStokKart projeStokKart);
        public Task<List<ProjeStokKart>> GetProjeStokKart(ProjeStokKart projeStokKart);
        public Task<List<ProjeBom>> GetProjeBomList(ProjeBom projeBomList);

    }
}
