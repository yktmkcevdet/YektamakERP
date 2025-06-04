using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;

namespace ApiService.Constants
{
    public class ApiBaseUrl
    {
        public const string localhostServer = "https://localhost:44314";
        public const string azureServer = "https://172.16.9.160:443";//"https://172.16.9.160:443";
        //public const string azureServer = "https://yektamakwebapp.azurewebsites.net";
        public static string server = GetServerUrl();
        public static string GetServerUrl()
        {
            if (IsIISRunning())
            {
                return localhostServer;
            }
            else
            {
                return azureServer;
            }
        }

        private static bool IsIISRunning()
        {
            try
            {
                using (TcpClient client = new TcpClient("localhost", 44314))
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string GetLogoAccessToken(string url,string userName,string password,string firmNr)
        {
            try
            {
                HttpWebRequest req = WebRequest.Create(new Uri(url)) as HttpWebRequest;
                req.Method = "POST";
                req.ContentType = "application/json";
                req.Accept = "application/json";
                req.Headers.Add("Authorization", "Basic REFUQU1FUjptNVFQWDJIZjE3Sm1NaXVVMC93NlBnR1FlQzE0MDBLbnZaZWk1V2J6UGF3PQ==");
                byte[] formData = UTF8Encoding.UTF8.GetBytes("grant_type=password"
                    + "&username=" + HttpUtility.UrlEncode(userName)   // bu satır 04.05.2020 tarihinde değiştirildi
                    + "&firmno=" + firmNr
                    + "&password=" + HttpUtility.UrlEncode(password)); // bu satır 04.05.2020 tarihinde değiştirildi
                req.ContentLength = formData.Length;
                using (Stream post = req.GetRequestStream())
                {
                    post.Write(formData, 0, formData.Length);
                }
                string result = null;
                using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(resp.GetResponseStream());
                    result = reader.ReadToEnd();
                }
                dynamic j = JsonConvert.DeserializeObject(result);
                return j.access_token;
            }
            catch (Exception e) {
                return e.Message;
            }

        }
    }
}
