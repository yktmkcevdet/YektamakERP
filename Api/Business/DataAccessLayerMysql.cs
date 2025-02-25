using Api.DatabaseJobs;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data.Common;
using System.Data;
using System.Reflection;
using System.Collections;

namespace Api.Business
{
    public class DataAccesLayerMySql : IDataAccessLayer
    {
        /// <summary>
		/// Verilen nesne modelinin içindeki verileri verilen sql komutu ile veritabanına kayıt eder.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="model"></param>
		/// <param name="sqlCommandName"></param>
		/// <returns></returns>
		public string SaveObject<T>(T model, string sqlCommandName) where T : class
        {
            MySqlConnection conn = DataBaseJobsGeneral.MySqlConnection();
            MySqlCommand cmd = new MySqlCommand(sqlCommandName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                AddParameters(model, cmd, "");

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                string returnValue = DataBaseJobsGeneral.SerializeObject(dataSet);
                return returnValue;
            }
            catch (Exception ex)
            {
                return "error 1 : veritabanı hatası " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// Verilen sql komutuna gönderilen filtre nesnesine göre dönen verileri json string olarak verir.
        /// </summary>
        /// <typeparam name="T">Filtre parametrelerini içeren nesne tipi</typeparam>
        /// <param name="model">Filtre parametrelerini içeren nesne adı</param>
        /// <param name="sqlCommandName">Sql komut nesnesi, genelde bir stored procedure'dür.</param>
        /// <returns></returns>
        public string GetObject<T>(T model, string sqlCommandName) where T : class
        {
            MySqlConnection conn = DataBaseJobsGeneral.MySqlConnection();
            MySqlCommand cmd = new MySqlCommand(sqlCommandName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                AddParameters(model, cmd, "");

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                string returnValue = DataBaseJobsGeneral.SerializeObject(dataSet);
                return returnValue;
            }
            catch (Exception ex)
            {
                return "error 1 : veritabanı hatası " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        
        public string GetObject<T>(string parameter, string sqlCommandName) where T : class
        {
            MySqlConnection conn = DataBaseJobsGeneral.MySqlConnection();
            MySqlCommand cmd = new MySqlCommand(sqlCommandName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                AddParameters(parameter, cmd);

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                string returnValue = DataBaseJobsGeneral.SerializeObject(dataSet);
                return returnValue;
            }
            catch (Exception ex)
            {
                return "error 1 : veritabanı hatası " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// Verilen sql komutundan dönen verileri json string olarak verir.
        /// </summary>
        /// <param name="sqlCommandName">Sql komut nesnesi, genelde bir stored procedure'dür.</param>
        /// <returns></returns>
        public string GetObject(string sqlCommandName)
        {
            MySqlConnection conn = DataBaseJobsGeneral.MySqlConnection();
            MySqlCommand cmd = new MySqlCommand(sqlCommandName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                GetStoredProcedureParameters(cmd);
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                string returnValue = DataBaseJobsGeneral.SerializeObject(dataSet);
                return returnValue;
            }
            catch (Exception ex)
            {
                return "error 1 : veritabanı hatası " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        public string DeleteObject<T>(T model, string sqlCommandName) where T : class
        {
            MySqlConnection conn = DataBaseJobsGeneral.MySqlConnection();
            MySqlCommand cmd = new MySqlCommand(sqlCommandName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                AddParameters(model, cmd, "");

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                return "Silme işlemi başarılı";
            }
            catch (Exception ex)
            {
                return "error 1 : veritabanı hatası " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// Sotored procedure'ün parametrelerini veritabanından alarak liste şeklinde verir.
        /// </summary>
        /// <param name="cmd">Parametreleri alınacak SqlCommand nesnesi</param>
        public void GetStoredProcedureParameters(MySqlCommand cmd)
        {
            MySqlCommandBuilder.DeriveParameters(cmd);
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            foreach (MySqlParameter parameter in cmd.Parameters)
            {
                MySqlParameter sqlParameter = new MySqlParameter();
                sqlParameter.ParameterName = parameter.ParameterName;
                sqlParameter.MySqlDbType = parameter.MySqlDbType;
                sqlParameter.Direction = parameter.Direction;
                if (parameter.MySqlDbType == MySqlDbType.VarChar)
                {
                    sqlParameter.Size = parameter.Size;
                }
                parameters.Add(sqlParameter);
            }
        }
        /// <summary>
        /// Stored procedure'un parametrelerinin değerleri, verilen modeldeki değerlere göre atanır.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">Parametre değerlerinin alınacağı veri modeli nesnesi</param>
        /// <param name="cmd">Parametrelerin ekleneceği stored procedure adı</param>
        /// <param name="parameterPrefix">Eğer model içinde model varsa üst model adı önek olarak parametreye eklenir.</param>
        public void AddParameters<T>(T model, MySqlCommand cmd, string parameterPrefix="") where T : class
        {
            if (model == null) return;
            if (cmd.Parameters.Count == 0)
            {
                if (cmd is DbCommand)
                {
                    GetStoredProcedureParameters(cmd);
                };
            }
            var memberList = model.GetType().GetMembers().Where(x => x.MemberType == MemberTypes.Property || x.MemberType == MemberTypes.Field).ToList();


            foreach (var member in memberList)
            {
                object field;
                string nnn = member.Name;
                if (member is FieldInfo fieldInfo)
                {
                    field = fieldInfo.GetValue(model);

                }
                else if (member is PropertyInfo propertyInfo)
                {
                    field = propertyInfo.GetValue(model);
                }
                else
                {
                    field = null;
                }
                if (field != null && field.GetType().IsClass && field.GetType() != typeof(string) && field.GetType() != typeof(byte[]))
                {
                    if (field.GetType().Name.Contains("List", StringComparison.OrdinalIgnoreCase))
                    {
                        //object value = field;
                        if (field is IEnumerable enumerable)
                        {
                            List<object> list = new List<object>();
                            foreach (var item in enumerable)
                            {
                                list.Add(item);
                            }
                            Type listType = field.GetType();
                            Type itemType = listType.GetGenericArguments()[0];
                            string jsonList = ListToJson(list, itemType);
                            foreach (MySqlParameter parameter in cmd.Parameters)
                            {
                                string parameterName = member.Name;
                                if (parameter.ParameterName.Substring(1, parameter.ParameterName.Length - 1).Equals(parameterName, StringComparison.OrdinalIgnoreCase))
                                {
                                    if (parameter.Value == null || parameter.Value.ToString() == "0" || parameter.Value.ToString() == "")
                                    {
                                        cmd.Parameters.RemoveAt(parameter.ParameterName);
                                        parameter.ParameterName = parameterName;
                                        parameter.Value = jsonList;
                                        //parameter.TypeName = "[dbo]." + parameterName;
                                        cmd.Parameters.Add(parameter);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        AddParameters(field, cmd, parameterPrefix + member.Name);//memberInfo class tipinde ise terkrar döngüye gir
                    }
                }
                foreach (MySqlParameter parameter in cmd.Parameters)
                {
                    string namem = member.Name;
                    string parameterName = parameterPrefix + member.Name;
                    if (parameter.ParameterName.Substring(1, parameter.ParameterName.Length - 1).Equals(parameterName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (parameter.Value == null || parameter.Value.ToString() == "0" || parameter.Value.ToString() == "")
                        {
                            cmd.Parameters.RemoveAt(parameter.ParameterName);
                            parameter.ParameterName = parameterName;
                            parameter.Value = field;
                            cmd.Parameters.Add(parameter);
                        }
                        break;
                    }
                }
            }


        }

        /// <summary>
        /// Liste şeklinde olan veri kümesini datatable nesnesine dönüştürür.
        /// </summary>
        /// <typeparam name="T">Dönüştürülecek nesne modeli.</typeparam>
        /// <param name="list">Datatable nesnesine dönüştürülecek veri listesi</param>
        /// <param name="sampleObject">Nesne modelinin elemanlarının okunabilmesi için listenin birinci elemanı nesne örneği olarak verilir.</param>
        /// <returns></returns>
        public DataTable ListToDataTable<T>(List<T> list, Type type) where T : class
        {
            DataTable table = new DataTable();
            //Eğer liste verisi değer tipinde ise(int,string gibi tek sütunlu değerler barındırıyorsa)
            if (type.IsValueType)
            {
                table.Columns.Add("Value");
                foreach (T item in list)
                {
                    DataRow row = table.NewRow();
                    row["Value"] = item;
                    table.Rows.Add(row);
                }
            }
            //Eğer liste verisi sınıf türünde değerler içeren liste ise
            else
            {
                foreach (MemberInfo memberInfo in type.GetMembers())
                {
                    if (memberInfo.MemberType == MemberTypes.Field || memberInfo.MemberType == MemberTypes.Property)
                    {
                        Type columnType = ((FieldInfo)memberInfo).FieldType;
                        table.Columns.Add(memberInfo.Name, columnType);
                    }
                }
                foreach (T item in list)
                {
                    if (item == null) continue;
                    DataRow row = table.NewRow();
                    foreach (DataColumn column in table.Columns)
                    {
                        FieldInfo fieldInfo = item.GetType().GetField(column.ColumnName);
                        if (fieldInfo != null)
                        {
                            object value = fieldInfo.GetValue(item);
                            row[column.ColumnName] = Convert.ChangeType(value, fieldInfo.FieldType) ?? DBNull.Value;
                        }
                    }

                    table.Rows.Add(row);
                }
            }
            return table;
        }
        public string ListToJson<T>(List<T> list, Type type) where T : class
        {
            if (list == null || list.Count == 0)
                return "[]"; // Boş bir JSON dizisi döner

            // Eğer liste verisi değer tipinde ise (int, string gibi)
            if (type.IsValueType || type == typeof(string))
            {
                var simpleList = list.Select(item => new { Value = item }).ToList();
                return JsonConvert.SerializeObject(simpleList); // Newtonsoft.Json kullanıyorsanız JsonConvert.SerializeObject
            }
            // Eğer liste sınıf türünde değerler içeriyorsa
            else
            {
                // Listeyi doğrudan JSON'a dönüştür
                return JsonConvert.SerializeObject(list); // Newtonsoft.Json alternatifi: JsonConvert.SerializeObject
            }
        }

        public string GetObject(string parameter, string sqlCommandName)
        {
            MySqlConnection conn = DataBaseJobsGeneral.MySqlConnection();
            MySqlCommand cmd = new MySqlCommand(sqlCommandName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                AddParameters(parameter, cmd);

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                string returnValue = DataBaseJobsGeneral.SerializeObject(dataSet);
                return returnValue;
            }
            catch (Exception ex)
            {
                return "error 1 : veritabanı hatası " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
