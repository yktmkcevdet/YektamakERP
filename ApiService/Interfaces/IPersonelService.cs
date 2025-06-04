using Models;

namespace ApiService.Interfaces
{
    public interface IPersonelService
    {
        public string GetPersonel(Personel personel);
        public Task<string> SavePersonel(Personel personel);
    }
}
