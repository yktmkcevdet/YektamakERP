using System.Data;

namespace Utilities.Interfaces
{
    public interface IJsonConvertHelper
    {
        public DataSet JsonStringToDataSet(string result);
    }
}
