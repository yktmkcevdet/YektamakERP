using Models;

namespace ApiService.Interfaces
{
    public interface IPersonelService
    {
        public string GetPersonel(Personel personel);
        public string GetPozisyon(Pozisyon pozisyon);
        public Task<string> SavePersonel(Personel personel);
        public Task<string> SavePersonelResim(PersonelResim personelResim);
        public Task<string> DeletePersonel(Personel personel);

    }
}
