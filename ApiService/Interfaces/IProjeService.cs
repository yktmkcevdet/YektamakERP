using Models;

namespace ApiService.Interfaces
{
    public interface IProjeService
    {
        public string GetProje(Proje proje);
        public string GetMarka();
        public string GetMarkaAltGrup();
        public string GetAllAssignedProjeKod();
        public Task<string> DeleteProjeDosya(Proje proje);

    }
}
