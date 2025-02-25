using Api.DatabaseJobs;
using Npgsql;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Collections;

namespace Api.Business
{
    public class DataAccessLayerPostgresql : IDataAccessLayer
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
            NpgsqlConnection conn = DataBaseJobsGeneral.PostgreSqlConnection();
            NpgsqlCommand cmd = new NpgsqlCommand(sqlCommandName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                AddParametersPostgresql(model, cmd, "");

                NpgsqlDataAdapter sqlDataAdapter = new NpgsqlDataAdapter(cmd);
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
            NpgsqlConnection conn = DataBaseJobsGeneral.PostgreSqlConnection();
            NpgsqlCommand cmd = new NpgsqlCommand(sqlCommandName, conn);
            cmd.CommandType = CommandType.Text;
            try
            {
                AddParametersPostgresql(model, cmd, "");
                List<NpgsqlParameter> parameters = GetFunctionParameters(conn, sqlCommandName);

                cmd.CommandText = $"SELECT * FROM {sqlCommandName}({string.Join(", ", parameters.ConvertAll(p => "@" + p.ParameterName))})";

                NpgsqlDataAdapter sqlDataAdapter = new NpgsqlDataAdapter(cmd);
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
            NpgsqlConnection conn = DataBaseJobsGeneral.PostgreSqlConnection();
            NpgsqlCommand cmd = new NpgsqlCommand(sqlCommandName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                NpgsqlDataAdapter sqlDataAdapter = new NpgsqlDataAdapter(cmd);
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
            NpgsqlConnection conn = DataBaseJobsGeneral.PostgreSqlConnection();
            NpgsqlCommand cmd = new NpgsqlCommand(sqlCommandName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                AddParametersPostgresql(model, cmd, "");

                NpgsqlDataAdapter sqlDataAdapter = new NpgsqlDataAdapter(cmd);
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
        public void GetStoredProcedureParameters(SqlCommand cmd)
        {
            SqlCommandBuilder.DeriveParameters(cmd);
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach (SqlParameter parameter in cmd.Parameters)
            {
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = parameter.ParameterName;
                sqlParameter.SqlDbType = parameter.SqlDbType;
                sqlParameter.Direction = parameter.Direction;
                if (parameter.SqlDbType == SqlDbType.NVarChar)
                {
                    sqlParameter.Size = parameter.Size;
                }
                parameters.Add(sqlParameter);
            }
        }
        /// <summary>
        /// Sotored procedure'ün parametrelerini veritabanından alarak liste şeklinde verir.
        /// </summary>
        /// <param name="cmd">Parametreleri alınacak SqlCommand nesnesi</param>
        public void GetStoredProcedureParametersPostgresql(NpgsqlCommand cmd)
        {
            List<NpgsqlParameter> parameters = GetFunctionParameters(DataBaseJobsGeneral.PostgreSqlConnection(), cmd.CommandText);

            // inputParameters listesindeki parametreleri cmd.Parameters'a ekle
            foreach (var inputParam in parameters)
            {
                cmd.Parameters.Add(inputParam);
            }
        }
        /// <summary>
        /// Stored procedure'un parametrelerinin değerleri, verilen modeldeki değerlere göre atanır.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">Parametre değerlerinin alınacağı veri modeli nesnesi</param>
        /// <param name="cmd">Parametrelerin ekleneceği stored procedure adı</param>
        /// <param name="parameterPrefix">Eğer model içinde model varsa üst model adı önek olarak parametreye eklenir.</param>
        public void AddParameters<T>(T model, SqlCommand cmd, string parameterPrefix) where T : class
        {
            if (model == null) return;
            if (cmd.Parameters.Count == 0)
            {
                GetStoredProcedureParameters(cmd);
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
                            DataTable dataTable = ListToDataTable(list, itemType);
                            foreach (SqlParameter parameter in cmd.Parameters)
                            {
                                string parameterName = member.Name;
                                if (parameter.ParameterName.Substring(1, parameter.ParameterName.Length - 1).Equals(parameterName, StringComparison.OrdinalIgnoreCase))
                                {
                                    if (parameter.Value == null || parameter.Value.ToString() == "0" || parameter.Value.ToString() == "")
                                    {
                                        cmd.Parameters.RemoveAt(parameter.ParameterName);
                                        parameter.ParameterName = parameterName;
                                        parameter.Value = dataTable;
                                        parameter.TypeName = "[dbo]." + parameterName;
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
                foreach (SqlParameter parameter in cmd.Parameters)
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
        /// Stored procedure'un parametrelerinin değerleri, verilen modeldeki değerlere göre atanır.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">Parametre değerlerinin alınacağı veri modeli nesnesi</param>
        /// <param name="cmd">Parametrelerin ekleneceği stored procedure adı</param>
        /// <param name="parameterPrefix">Eğer model içinde model varsa üst model adı önek olarak parametreye eklenir.</param>
        public void AddParametersPostgresql<T>(T model, NpgsqlCommand cmd, string parameterPrefix) where T : class
        {
            if (model == null) return;
            if (cmd.Parameters.Count == 0)
            {
                GetStoredProcedureParametersPostgresql(cmd);
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
                            DataTable dataTable = ListToDataTable(list, itemType);
                            foreach (NpgsqlParameter parameter in cmd.Parameters)
                            {
                                string parameterName = member.Name;
                                if (parameter.ParameterName.Substring(0, parameter.ParameterName.Length - 0).Equals(parameterName, StringComparison.OrdinalIgnoreCase))
                                {
                                    if (parameter.Value == null || parameter.Value.ToString() == "0" || parameter.Value.ToString() == "")
                                    {
                                        cmd.Parameters.RemoveAt(parameter.ParameterName);
                                        parameter.ParameterName = parameterName;
                                        parameter.Value = dataTable;
                                        parameter.DataTypeName = "public." + parameterName;
                                        cmd.Parameters.Add(parameter);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        AddParametersPostgresql(field, cmd, parameterPrefix + member.Name);//memberInfo class tipinde ise terkrar döngüye gir
                    }
                }
                foreach (NpgsqlParameter parameter in cmd.Parameters)
                {
                    string namem = member.Name;
                    string parameterName = parameterPrefix + member.Name;
                    if (parameter.ParameterName.Substring(0, parameter.ParameterName.Length - 0).Equals(parameterName, StringComparison.OrdinalIgnoreCase))
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
        static List<NpgsqlParameter> GetFunctionParameters(NpgsqlConnection conn, string functionName)
        {
            var parameters = new List<NpgsqlParameter>();

            string query = @"
            SELECT parameter_name, data_type
            FROM information_schema.parameters
            WHERE specific_name LIKE @functionName || '%' AND parameter_mode='IN'
            ORDER BY ordinal_position;";

            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@functionName", functionName.ToLower());

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string paramName = reader.GetString(0);
                        string dataType = reader.GetString(1);

                        NpgsqlParameter parameter = new NpgsqlParameter(paramName, GetNpgsqlDbType(dataType));
                        parameters.Add(parameter);
                    }
                }
            }

            return parameters;
        }

        static NpgsqlTypes.NpgsqlDbType GetNpgsqlDbType(string dataType)
        {
            switch (dataType.ToLower())
            {
                case "bigint":
                    return NpgsqlTypes.NpgsqlDbType.Integer;
                case "character varying":
                    return NpgsqlTypes.NpgsqlDbType.Varchar;
                case "boolean":
                    return NpgsqlTypes.NpgsqlDbType.Boolean;
                // Diğer veri tiplerini ekleyin
                default:
                    throw new NotSupportedException($"Unsupported data type: {dataType}");
            }
        }

        public string GetObject(string parameter, string sqlCommandName)
        {
            throw new NotImplementedException();
        }
    }
}
