using Newtonsoft.Json;
using System.Data;
using System.Text;
using Utilities.Interfaces;

namespace Utilities.Implementations
{
    public class JsonConvertHelper:IJsonConvertHelper
    {
        public string JsonStringToString(string result)
        {
            byte[] bytes = JsonConvert.DeserializeObject<byte[]>(result);
            return Encoding.UTF8.GetString(bytes);
        }
        public string StringToJsonString(string result)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(result);
            return JsonConvert.SerializeObject(bytes);
        }
        /// <summary>
        /// web isteklerinden dönen json değerlerini dataset nesnesine dönüştürür
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public DataSet JsonStringToDataSet(string result)
        {
            DataSet dataSet = new DataSet(); // Default empty DataSet

            if (!result.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(result);
                string json = Encoding.UTF8.GetString(bytes);
                dataSet = JsonConvert.DeserializeObject<DataSet>(json);
            }
            else
            {
                //MessageBox.Show(result);
                dataSet = null;
            }

            return dataSet;
        }

        public T JsonStringToModel<T>(string result)
        {
            byte[] bytes = JsonConvert.DeserializeObject<byte[]>(result);
            string json = Encoding.UTF8.GetString(bytes);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public string ModelToJsonString<T>(T model)
        {
            string json= JsonConvert.SerializeObject(model);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            return JsonConvert.SerializeObject(bytes);
        }
    }
}
