using Models;

namespace ApiService.Implementetions
{
    public interface IUserService
    {
        Task<Kullanici> GetKullaniciAsync(string username);
    }
}
