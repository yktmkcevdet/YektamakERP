using Microsoft.Extensions.Logging;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Text;
using Utilities.Interfaces;

namespace Utilities.Implementations
{
    public class JsonConverter : IJsonConverter
    {
        private readonly ILogger<JsonConverter> _logger;
        private readonly IDataTableMapper _dataTableMapper;

        public JsonConverter(ILogger<JsonConverter> logger = null, IDataTableMapper dataTableMapper = null)
        {
            _logger = logger;
            _dataTableMapper = dataTableMapper;
        }

        /// <summary>
        /// Base64 ile encode edilmiş JSON string'i decode eder
        /// </summary>
        /// <param name="encodedJsonString">Base64 encode edilmiş JSON string</param>
        /// <returns>Düz metin JSON string</returns>
        /// <exception cref="ArgumentException">Geçersiz parametre durumunda</exception>
        /// <exception cref="JsonException">JSON deserializasyon hatası durumunda</exception>
        public string DecodeBase64JsonString(string encodedJsonString)
        {
            if (string.IsNullOrWhiteSpace(encodedJsonString))
                throw new ArgumentException("Encoded JSON string cannot be null or empty.", nameof(encodedJsonString));

            try
            {
                var bytes = JsonConvert.DeserializeObject<byte[]>(encodedJsonString);
                if (bytes == null)
                    throw new JsonException("Failed to deserialize byte array from JSON string.");

                return Encoding.UTF8.GetString(bytes);
            }
            catch (JsonException ex)
            {
                _logger?.LogError(ex, "Failed to decode Base64 JSON string: {EncodedString}", encodedJsonString);
                throw new JsonException("Invalid encoded JSON string format.", ex);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Unexpected error while decoding JSON string: {EncodedString}", encodedJsonString);
                throw;
            }
        }

        /// <summary>
        /// Düz metni Base64 ile encode edilmiş JSON string'e dönüştürür
        /// </summary>
        /// <param name="plainText">Encode edilecek düz metin</param>
        /// <returns>Base64 encode edilmiş JSON string</returns>
        /// <exception cref="ArgumentException">Geçersiz parametre durumunda</exception>
        public string EncodeStringToBase64Json(string plainText)
        {
            if (plainText == null)
                throw new ArgumentException("Plain text cannot be null.", nameof(plainText));

            try
            {
                var bytes = Encoding.UTF8.GetBytes(plainText);
                return JsonConvert.SerializeObject(bytes);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Failed to encode string to Base64 JSON: {PlainText}", plainText);
                throw;
            }
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

            if (ContainsError(encodedJsonString))
            {
                _logger?.LogWarning("Error detected in JSON response: {Response}", encodedJsonString);
                return null;
            }

            try
            {
                var decodedJson = DecodeBase64JsonString(encodedJsonString);
                var dataSet = JsonConvert.DeserializeObject<DataSet>(decodedJson);

                _logger?.LogDebug("Successfully deserialized DataSet from JSON string.");
                return dataSet ?? new DataSet();
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Failed to deserialize JSON string to DataSet: {EncodedString}", encodedJsonString);
                return null;
            }
        }

        /// <summary>
        /// Encode edilmiş JSON string'i belirtilen model tipine dönüştürür
        /// </summary>
        /// <typeparam name="T">Dönüştürülecek model tipi</typeparam>
        /// <param name="encodedJsonString">Base64 encode edilmiş JSON string</param>
        /// <returns>Deserialize edilmiş model nesnesi</returns>
        /// <exception cref="ArgumentException">Geçersiz parametre durumunda</exception>
        /// <exception cref="JsonException">Deserializasyon hatası durumunda</exception>
        public List<T> DeserializeToModelList<T>(string encodedJsonString) where T : IEntity, new()
        {
            if (string.IsNullOrWhiteSpace(encodedJsonString))
                throw new ArgumentException("Encoded JSON string cannot be null or empty.", nameof(encodedJsonString));

            try
            {
                var decodedJson = DecodeBase64JsonString(encodedJsonString);
                var obj = JObject.Parse(decodedJson);
                var jsonModel = obj["Table"].FirstOrDefault();
                //var model=jsonModel.ToObject<T>();

                var dataTable = DeserializeToDataSet(encodedJsonString)?.Tables[0];
                var modelList = _dataTableMapper.MapToEntityList<T>(dataTable) ;

                _logger?.LogDebug("Successfully deserialized model of type {ModelType}.", typeof(T).Name);
                return modelList;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Failed to deserialize JSON string to model of type {ModelType}: {EncodedString}",
                                 typeof(T).Name, encodedJsonString);
                throw;
            }
        }

        /// <summary>
        /// Model nesnesini Base64 encode edilmiş JSON string'e dönüştürür
        /// </summary>
        /// <typeparam name="T">Serialize edilecek model tipi</typeparam>
        /// <param name="model">Serialize edilecek model nesnesi</param>
        /// <returns>Base64 encode edilmiş JSON string</returns>
        /// <exception cref="ArgumentNullException">Model null durumunda</exception>
        public string SerializeModelToEncodedJson<T>(T model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "Model cannot be null.");

            try
            {
                var json = JsonConvert.SerializeObject(model, Formatting.None);
                var encodedJson = EncodeStringToBase64Json(json);

                _logger?.LogDebug("Successfully serialized model of type {ModelType} to encoded JSON.", typeof(T).Name);
                return encodedJson;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Failed to serialize model of type {ModelType} to encoded JSON.", typeof(T).Name);
                throw;
            }
        }

        /// <summary>
        /// Encode edilmiş JSON string'in geçerli olup olmadığını kontrol eder
        /// </summary>
        /// <param name="encodedJsonString">Kontrol edilecek JSON string</param>
        /// <returns>Geçerli ise true, değilse false</returns>
        public bool IsValidEncodedJson(string encodedJsonString)
        {
            if (string.IsNullOrWhiteSpace(encodedJsonString))
                return false;

            try
            {
                DecodeBase64JsonString(encodedJsonString);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// JSON response'unda hata olup olmadığını kontrol eder
        /// </summary>
        /// <param name="jsonResponse">Kontrol edilecek JSON response</param>
        /// <returns>Hata varsa true, yoksa false</returns>
        private static bool ContainsError(string jsonResponse)
        {
            return jsonResponse.Contains("error", StringComparison.OrdinalIgnoreCase);
        }
    }

    // Extension Methods (Utilities/Extensions klasörüne)
    public static class JsonConverterExtensions
    {
        /// <summary>
        /// String'i güvenli şekilde encode edilmiş JSON'a dönüştürür
        /// </summary>
        public static string ToEncodedJson(this string plainText, IJsonConverter converter)
        {
            return string.IsNullOrEmpty(plainText) ? string.Empty : converter.EncodeStringToBase64Json(plainText);
        }

        /// <summary>
        /// Encode edilmiş JSON'u güvenli şekilde decode eder
        /// </summary>
        public static string FromEncodedJson(this string encodedJson, IJsonConverter converter)
        {
            return string.IsNullOrWhiteSpace(encodedJson) ? string.Empty : converter.DecodeBase64JsonString(encodedJson);
        }

        /// <summary>
        /// Model'i güvenli şekilde encode edilmiş JSON'a dönüştürür
        /// </summary>
        public static string ToEncodedJson<T>(this T model, IJsonConverter converter)
        {
            return model == null ? string.Empty : converter.SerializeModelToEncodedJson(model);
        }
    }
}
