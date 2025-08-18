using Models;
using System.Data;

namespace Utilities.Interfaces
{
    public interface IJsonConverter
    {
        DataSet DeserializeToDataSet(string result);
        public T? DeserializeObject<T>(string value);
    }
}
