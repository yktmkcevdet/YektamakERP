using System.Data;

namespace Utilities.Interfaces
{
    public interface IJsonConvertHelper
    {
        public DataSet JsonStringToDataSet(string result);
        public string ModelToJsonString<T>(T model);
        public T JsonStringToModel<T>(string result);
        public string JsonStringToString(string result);
        public string StringToJsonString(string result);
    }
}
