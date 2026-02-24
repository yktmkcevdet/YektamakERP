using Models;
using System.Data;

namespace Utilities.Interfaces
{
    public interface IConvertHelper
    {
        /// <summary>
        /// Model listesini datatable'a çevirir.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable ToDataTable<T>(List<T> data) where T : IEntity, new();
        /// <summary>
        /// Model içindeki Field ve Property'leri DataTable'a sütun olarak ekler
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsComplexType(Type type);
        public T ToEntity<T>(object dto, object entity = null, string classNamePrefix = "") where T : class, new();
        public T ToDTO<T>(object entity, string parentName = "", object dto = null) where T : IEntity, new();
    }
}
