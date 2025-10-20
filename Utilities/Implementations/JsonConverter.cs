using Microsoft.Extensions.Logging;
using Models;
using Newtonsoft.Json;
using System.Data;
using System.Text;
using Utilities.Implementations.Converters;
using Utilities.Interfaces;

namespace Utilities.Implementations
{
    public class JsonConverter : IJsonConverter
    {
        private readonly ILogger<JsonConverter> _logger;
        private readonly IDataTableMapper _dataTableMapper;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public JsonConverter(ILogger<JsonConverter> logger = null, IDataTableMapper dataTableMapper = null)
        {
            _logger = logger;
            _dataTableMapper = dataTableMapper;
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateFormatString = "yyyy-MM-dd HH:mm:ss",
                Converters = new List<Newtonsoft.Json.JsonConverter>
                {
                    new MultiFormatDateTimeConverter(),
                    new GuidConverter()
                }
            };
        }
        /// <summary>
        /// Web isteklerinden dönen encode edilmiş JSON değerlerini DataSet nesnesine dönüştürür
        /// </summary>
        /// <param name="encodedJsonString">Base64 encode edilmiş JSON string</param>
        /// <returns>DataSet nesnesi, hata durumunda null</returns>
        public DataSet DeserializeToDataSet(string encodedJsonString)
        {
            if (string.IsNullOrWhiteSpace(encodedJsonString))
            {
                _logger?.LogWarning("Empty or null JSON string provided for DataSet deserialization.");
                return new DataSet();
            }
            try
            {
                var dataSet = JsonConvert.DeserializeObject<DataSet>(encodedJsonString, _jsonSerializerSettings);

                _logger?.LogDebug("Successfully deserialized DataSet from JSON string.");
                return dataSet ?? new DataSet();
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Failed to deserialize JSON string to DataSet: {EncodedString}", encodedJsonString);
                return null;
            }
        }
        public T? DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value, _jsonSerializerSettings);
        }
    }
}
