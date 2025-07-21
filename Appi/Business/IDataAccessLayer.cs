using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Appi.Business
{
    public interface IDataAccessLayer
    {
        string SaveObject<T>(T model, string sqlCommandName) where T : class;
        string SaveObject(string json, string sqlCommandName);
        string GetObject<T>(T model, string sqlCommandName) where T : class;
        string GetObject(string sqlCommandName);
        /// <summary>
        /// Verilen sql komutuna gönderilen filtre nesnesine göre dönen verileri json string olarak verir.
        /// </summary>
        /// <typeparam name="T">Filtre parametrelerini içeren nesne tipi</typeparam>
        /// <param name="parameter">Sorgu parametresini içeren değişken(Genelde Id'dir)</param>
        /// <param name="sqlCommandName">Sql komut nesnesi, genelde bir stored procedure'dür.</param>
        /// <returns></returns>
        string GetObject(string parameter,string sqlCommandName);
        string DeleteObject<T>(T model, string sqlCommandName) where T : class;
        //void GetStoredProcedureParameters<T>(T cmd) where T : DbCommand;
        //void AddParameters<T, U>(T model, U cmd, string parameterPrefix) where T : class where U : DbCommand;
        DataTable ListToDataTable<T>(List<T> list, Type type) where T : class;
    }
    public interface IDataAccessLayerAsync
    {
        Task<string> SaveObjectAsync<T>(T model, string sqlCommandName) where T : class;
        Task<string> GetObjectAsync<T>(T model, string sqlCommandName) where T : class;
        Task<string> GetObjectAsync(string sqlCommandName);
        Task<string> GetObjectAsync(string parameter, string sqlCommandName);
        Task<string> DeleteObjectAsync<T>(T model, string sqlCommandName) where T : class;
        DataTable ListToDataTable<T>(List<T> list, Type type) where T : class;
    }
}
