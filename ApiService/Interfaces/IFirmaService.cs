using Models;

namespace ApiService.Interfaces
{
    public interface IFirmaService
    {
        public List<Firma> SaveFirma(Firma firma);
        public List<Firma> GetFirma(Firma firma);
        public string GetSektor(Sektor setkor);
        public List<Adres> GetAdres(Adres adres);
        public List<Adres> SaveAdres(Adres adres);
        public string DeleteAdres(Adres adres);
    }
}
