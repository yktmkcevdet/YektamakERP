using Models;

namespace ApiService.Interfaces
{
    public interface IUserService
    {
        Task<Kullanici> GetKullaniciAsync(string username);
    }
}
