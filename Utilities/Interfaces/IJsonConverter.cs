using Models;
using System.Data;

namespace Utilities.Interfaces
{
    public interface IJsonConverter
    {
        DataSet DeserializeToDataSet(string result);
        string SerializeModelToEncodedJson<T>(T model);
        List<T> DeserializeToModelList<T>(string result) where T : IEntity, new();
        string DecodeBase64JsonString(string result);
        string EncodeStringToBase64Json(string result);
        bool IsValidEncodedJson(string encodedJsonString);
        public List<T> ToModelList<T>(string encodedJsonString) where T : IEntity, new();
    }
}
