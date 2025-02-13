namespace ApiService.Interfaces
{
    public interface IApiService
    {
        Task<string> PostAsync<T>(T entity, string apiAdres) where T : class;
        Task<string> GetAsync(string apiAdres);
        Task<string> DeleteAsync<T>(T entity, string apiAdres) where T : class;
    }
}
