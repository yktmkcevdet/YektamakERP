using Models;
using Models.DTO;

namespace ApiService.Interfaces
{
    public interface IConfigurationService
    {
        public Task<string> SaveGridSettings(GridSettings gridSettings);
        public Task<string> GetGridSettings(GridSettings gridSettings);
        public Task<string> GetDosyalamaYapisi(DosyalamaYapisi dosyalamaYapisi);
    }
}
