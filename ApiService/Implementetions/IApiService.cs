using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Implementetions
{
    public interface IApiService
    {
        Task<string> PostAsync<T>(T entity, string apiAdres) where T : class;
        Task<string> GetAsync(string apiAdres);
        Task<string> DeleteAsync<T>(T entity, string apiAdres) where T : class;
    }
}
