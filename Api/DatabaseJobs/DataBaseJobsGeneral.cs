using Api.Converters;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Npgsql;
using System.Data.SqlClient;
namespace Api.DatabaseJobs
{
    public static partial class DataBaseJobsGeneral
    {
        //private const string connectionString = "Server=tcp:yektamak.database.windows.net,1433;Initial Catalog=yektamakDB;Persist Security Info=False;User ID=yektamakAdmin;Password=Yektamak@dmin;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //private const string connectionString = "Server=YEKTAMAK-144;Initial Catalog=yektamakDB;Persist Security Info=False;User ID=yektamakAdmin;Password=Yektamak@dmin;MultipleActiveResultSets=False;Encrypt=False;Connection Timeout=30;";
        private const string connectionString = "Host=127.0.0.1;Username=postgres;Password=1;Database=yektamakDB";

        internal static JsonConverter[] jsonConverters = new JsonConverter[] { new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" } };
        internal static JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            DateFormatString = "yyyy-MM-dd HH:mm:ss",
            Converters = new List<JsonConverter>
                {
                    new MultiFormatDateTimeConverter()
                }
        };

        internal static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection("Server=YEKTAMAK-144;Initial Catalog=yektamakDB;Persist Security Info=False;User ID=yektamakAdmin;Password=Yektamak@dmin;MultipleActiveResultSets=False;Encrypt=False;Connection Timeout=30;");
            try
            {
                connection.Open();
                return connection;
            }
            catch (Exception)
            {
                return null;
            }
        }
        internal static NpgsqlConnection PostgreSqlConnection()
        {
            NpgsqlConnection npgsqlConnection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=1;Database=yktmkdb");
            try
            {
                npgsqlConnection.Open();
                return npgsqlConnection;
            }
            catch
            {
                return null;
            }
        }
        internal static MySqlConnection MySqlConnection()
        {
            MySqlConnection mySqlConnection = new MySqlConnection("Server=172.16.9.160;Database=YektamakDb;User ID=YektamakAdmin;Password=Yektamak@dmin;");
            try
            {
                mySqlConnection.Open();
                return mySqlConnection;
            }
            catch
            {
                return null;
            }
        }
        internal static MySqlConnection MySqlConnectionYerel()
        {
            MySqlConnection mySqlConnection = new MySqlConnection("Server=172.16.9.160;Database=YektamakDb;User ID=YektamakAdmin;Password=Yektamak@dmin;");
            //MySqlConnection mySqlConnection = new MySqlConnection("Server=127.0.0.1;Database=YektamakDb;User ID=root;Password=Yektamak@dmin;");
            try
            {
                mySqlConnection.Open();
                return mySqlConnection;
            }
            catch
            {
                return null;
            }
        }

        internal static string SerializeObject(object o)
        {
            string result = "";
            try
            {
                string firstSerialization = JsonConvert.SerializeObject(o);
                //byte[] data = System.Text.Encoding.UTF8.GetBytes(firstSerialization);
                //result = JsonConvert.SerializeObject(data);
                result = firstSerialization;
            }
            catch (Exception ex)
            {
                result= "error2 : Serileştirme hatası : " + ex.Message;
            }
            return result;
        }
		
	}
}
