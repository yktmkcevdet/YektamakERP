using Models;
using System.Data;

namespace Utilities.Interfaces
{
    public interface IDataTableConverter
    {
        public List<T> ToList<T>(List<DataRow> dt) where T : IEntity, new();
        public T DataRowToModel<T>(DataRow dataRow, string upClassName = "") where T : IEntity, new();
    }
}
