using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Interfaces;

namespace Utilities.Implementations
{
    public class JsonConvertHelper:IJsonConvertHelper
    {
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
    }
}
