using System.Data;

namespace Utilities.Interfaces
{
    public interface IJsonConverter
    {
        DataSet DeserializeToDataSet(string result);
        string SerializeModelToEncodedJson<T>(T model);
        T DeserializeToModel<T>(string result);
        string DecodeBase64JsonString(string result);
        string EncodeStringToBase64Json(string result);
        bool IsValidEncodedJson(string encodedJsonString);
    }
}
