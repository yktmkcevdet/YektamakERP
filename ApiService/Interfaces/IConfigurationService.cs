using Models;

namespace ApiService.Interfaces
{
    public interface IConfigurationService
    {
        public Task<string> SaveGridSettings(GridSettings gridSettings);
        public Task<string> GetGridSettings(GridSettings gridSettings);
    }
}
