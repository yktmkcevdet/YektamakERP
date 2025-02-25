using Api.DatabaseJobs;
using Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Org.BouncyCastle.Ocsp;

namespace Api.Controllers
{
	public class GeneralMethods
	{
		public static string ResultData<T>(string restData) where T : class
		{
            string json = JsonConvert.SerializeObject(restData);
			byte[] bytes = Encoding.UTF8.GetBytes(json);
			string entity = JsonConvert.SerializeObject(bytes);
            return entity;
		}
        public static string ResultData(string restData) 
        {
            string json = JsonConvert.SerializeObject(restData);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            string result = JsonConvert.SerializeObject(bytes);
            return result;
        }
        public static T JsonStringToModel<T>(string restData)
        {
            restData = (restData[0] == '\"') ? restData : "\"" + restData;
            restData = (restData[restData.Length - 1] == '\"') ? restData : restData + "\"";
            byte[] bytes = JsonConvert.DeserializeObject<byte[]>(restData);
            string json = Encoding.UTF8.GetString(bytes);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string ModelToJsonString<T>(T model)
        {
            string json = JsonConvert.SerializeObject(model);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            return JsonConvert.SerializeObject(bytes);
        }
        public static string JsonStringToString(string restData)
        {
            restData=(restData[0] == '\"') ? restData : "\"" + restData;
            restData = (restData[restData.Length - 1] == '\"') ? restData : restData + "\"";
            byte[] bytes = JsonConvert.DeserializeObject<byte[]>(restData??"");
            return Encoding.UTF8.GetString(bytes);
        }
        public static string StringToJsonString(string restData)
        {
            restData = (restData[0] == '\"') ? restData : "\"" + restData;
            restData = (restData[restData.Length - 1] == '\"') ? restData : restData + "\"";
            byte[] bytes = Encoding.UTF8.GetBytes(restData);
            return JsonConvert.SerializeObject(bytes);
        }
    }
}
