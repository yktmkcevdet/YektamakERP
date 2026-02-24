using Models;

namespace Api.Interfaces
{
    public interface IProjeStokKartService
    {
        public Task<string> SaveProjeStokKartAsync(ProjeStokKart model);
    }
}
