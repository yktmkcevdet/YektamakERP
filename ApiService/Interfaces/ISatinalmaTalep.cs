using Models;

namespace ApiService.Interfaces
{
    public interface ISatinalmaTalep
    {
        public Task<string> SaveSatinalmaTalep(SatinalmaTalepBaslik satinalmaTalepBaslik);
    }
}
