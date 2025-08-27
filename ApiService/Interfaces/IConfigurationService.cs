using Models;
using Models.Configuration;

namespace ApiService.Interfaces
{
    public interface IConfigurationService
    {
        public Task<string> SaveGridSettings(GridSettings gridSettings);
        public Task<string> GetGridSettings(GridSettings gridSettings);
        public Task<string> GetDosyalamaYapisi(DosyalamaYapisi dosyalamaYapisi);
    }
}
