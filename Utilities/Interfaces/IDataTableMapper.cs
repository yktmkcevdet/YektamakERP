using Models;
using System.ComponentModel;
using System.Data;

namespace Utilities.Interfaces
{
    public interface IDataTableMapper
    {
        public List<T> MapToEntityList<T>(DataTable dt) where T : IEntity, new();
        /// <summary>
        /// DataRow to Entity Mapper
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataRow"></param>
        /// <param name="classNamePrefix"></param>
        /// <returns></returns>
        public T MapToEntity<T>(DataRow dataRow, string classNamePrefix = "") where T : IEntity, new();
    }
}
