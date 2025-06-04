using Models;

namespace ApiService.Interfaces
{
    public interface IUserService
    {
        public Task<Kullanici> GetKullaniciAsync(string username);
    }
}
