using Models;
using System.Data;

namespace Utilities.Interfaces
{
    public interface IDataTableMapper
    {
        public List<T> MapToEntityList<T>(List<DataRow> dt) where T : IEntity, new();
        public T MapToEntity<T>(DataRow dataRow, string classNamePrefix = "") where T : IEntity, new();
    }
}
