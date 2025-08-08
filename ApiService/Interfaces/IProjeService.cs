using Models;

namespace ApiService.Interfaces
{
    public interface IProjeService
    {
        public string GetProje(Proje proje);
        public string GetProjeTip();
        public string GetMarka();
        public string GetMarkaAltGrup();
        public string GetMarkaAltGrupKategori();
        public string GetAllAssignedProjeKod();
        public Task<string> DeleteProjeDosya(Proje proje);
        public Task<string> SaveProjeStokKart(ProjeStokKart projeStokKart);
        public string SaveProje(Proje proje);
        public Task<string> DeleteProjeStokKart(ProjeStokKart projeStokKart);
        public Task<string> GetProjeStokKart(ProjeStokKart projeStokKart);

    }
}
