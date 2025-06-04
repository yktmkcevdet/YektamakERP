using Models;

namespace ApiService.Interfaces
{
    public interface IFirmaService
    {
        public string GetFirma(Firma firma=null);
        public string GetSektor(Sektor setkor);
    }
}
