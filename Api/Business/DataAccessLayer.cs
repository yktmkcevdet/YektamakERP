using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Collections;
using System.Data;
using System.Reflection;

namespace Api.Business
{
    public class DataAccessLayer:IDataAccessLayerAsync
    {
        private readonly string _connectionString;
        private readonly ILogger<DataAccessLayer> _logger;
        public DataAccessLayer(IConfiguration configuration, ILogger<DataAccessLayer> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }
        /// <summary>
        /// Verilen nesne modelinin içindeki verileri verilen sql komutu ile veritabanına kayıt eder.
        /// </summary>
        public async Task<string> SaveObjectAsync<T>(T model, string sqlCommandName) where T : class
        {
            MySqlConnection conn = null;
            try
            {
                conn = await GetConnectionAsync();
                if (conn == null)
                {
                    return JsonConvert.SerializeObject(new { error = "Veritabanı bağlantısı kurulamadı" });
                }

                using var cmd = new MySqlCommand(sqlCommandName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300; // 5 dakika timeout

                // Parametreleri ekle
                AddParameters(model, cmd, "");

                // Stored procedure'ü çalıştır ve sonucu al
                using var adapter = new MySqlDataAdapter(cmd);
                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                // Sonucu JSON olarak serialize et
                var result = SerializeDataSet(dataSet);
                _logger.LogInformation($"SaveObject başarılı: {sqlCommandName}");

                return result;
            }
            catch (MySqlException ex)
            {
                var errorMessage = $"MySQL Hatası - Kod: {ex.Number}, Mesaj: {ex.Message}";
                _logger.LogError(ex, $"SaveObject hatası: {sqlCommandName}");

                // Deadlock kontrolü
                if (ex.Number == 1213)
                {
                    return JsonConvert.SerializeObject(new { error = "Deadlock tespit edildi, lütfen tekrar deneyin", code = ex.Number });
                }

                return JsonConvert.SerializeObject(new { error = errorMessage, code = ex.Number });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"SaveObject genel hatası: {sqlCommandName}");
                return JsonConvert.SerializeObject(new { error = $"Genel hata: {ex.Message}" });
            }
            finally
            {
                conn?.Close();
            }
        }

        public async Task<string> GetObjectAsync<T>(T model, string sqlCommandName) where T : class
        {
            MySqlConnection conn = null;
            try
            {
                conn = await GetConnectionAsync();
                if (conn == null)
                {
                    return JsonConvert.SerializeObject(new { error = "Veritabanı bağlantısı kurulamadı" });
                }

                using var cmd = new MySqlCommand(sqlCommandName, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                AddParameters(model, cmd, "");

                using var adapter = new MySqlDataAdapter(cmd);
                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                return SerializeDataSet(dataSet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetObject hatası: {sqlCommandName}");
                return JsonConvert.SerializeObject(new { error = ex.Message });
            }
            finally
            {
                conn?.Close();
            }
        }

        public async Task<string> GetObjectAsync(string sqlCommandName)
        {
            MySqlConnection conn = null;
            try
            {
                conn = await GetConnectionAsync();
                if (conn == null)
                {
                    return JsonConvert.SerializeObject(new { error = "Veritabanı bağlantısı kurulamadı" });
                }

                using var cmd = new MySqlCommand(sqlCommandName, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                using var adapter = new MySqlDataAdapter(cmd);
                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                return SerializeDataSet(dataSet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetObject hatası: {sqlCommandName}");
                return JsonConvert.SerializeObject(new { error = ex.Message });
            }
            finally
            {
                conn?.Close();
            }
        }

        public async Task<string> GetObjectAsync(string parameter, string sqlCommandName)
        {
            MySqlConnection conn = null;
            try
            {
                conn = await GetConnectionAsync();
                if (conn == null)
                {
                    return JsonConvert.SerializeObject(new { error = "Veritabanı bağlantısı kurulamadı" });
                }

                using var cmd = new MySqlCommand(sqlCommandName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@parameter", parameter);

                using var adapter = new MySqlDataAdapter(cmd);
                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                return SerializeDataSet(dataSet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetObject hatası: {sqlCommandName}");
                return JsonConvert.SerializeObject(new { error = ex.Message });
            }
            finally
            {
                conn?.Close();
            }
        }

        public async Task<string> DeleteObjectAsync<T>(T model, string sqlCommandName) where T : class
        {
            return await SaveObjectAsync(model, sqlCommandName); // Aynı mantık
        }

        /// <summary>
        /// Stored procedure'un parametrelerinin değerleri, verilen modeldeki değerlere göre atanır.
        /// </summary>
        public void AddParameters<T>(T model, MySqlCommand cmd, string parameterPrefix = "") where T : class
        {
            if (model == null) return;

            // Stored procedure parametrelerini al
            if (cmd.Parameters.Count == 0)
            {
                GetStoredProcedureParameters(cmd);
            }

            var properties = model.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var value = property.GetValue(model);
                var propertyName = parameterPrefix + property.Name;

                // Eğer değer bir sınıf ise (string ve byte[] hariç)
                if (value != null && property.PropertyType.IsClass &&
                    property.PropertyType != typeof(string) &&
                    property.PropertyType != typeof(byte[]))
                {
                    // Liste kontrolü
                    if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType) &&
                        property.PropertyType != typeof(string))
                    {
                        var jsonValue = JsonConvert.SerializeObject(value);
                        SetParameterValue(cmd, property.Name, jsonValue);
                    }
                    else
                    {
                        // Alt nesne için recursive çağrı
                        AddParameters(value, cmd, propertyName);
                    }
                }
                else
                {
                    // Basit tip için parametre değeri ata
                    SetParameterValue(cmd, propertyName, value);
                }
            }
        }

        private void SetParameterValue(MySqlCommand cmd, string parameterName, object value)
        {
            var parameter = cmd.Parameters.Cast<MySqlParameter>()
                .FirstOrDefault(p => string.Equals(p.ParameterName.TrimStart('@'), parameterName, StringComparison.OrdinalIgnoreCase));

            if (parameter != null)
            {
                parameter.Value = value ?? DBNull.Value;
            }
        }

        private void GetStoredProcedureParameters(MySqlCommand cmd)
        {
            try
            {
                // MySQL'de stored procedure parametrelerini otomatik almak için
                // INFORMATION_SCHEMA.PARAMETERS tablosunu kullanabiliriz
                using var tempCmd = new MySqlCommand($@"
                SELECT PARAMETER_NAME, DATA_TYPE, IS_NULLABLE
                FROM INFORMATION_SCHEMA.PARAMETERS 
                WHERE SPECIFIC_NAME = '{cmd.CommandText}' 
                AND SPECIFIC_SCHEMA = DATABASE()
                ORDER BY ORDINAL_POSITION", cmd.Connection);

                using var reader = tempCmd.ExecuteReader();
                var parameters = new List<MySqlParameter>();

                while (reader.Read())
                {
                    var paramName = reader["PARAMETER_NAME"].ToString();
                    var dataType = reader["DATA_TYPE"].ToString();

                    var parameter = new MySqlParameter($"@{paramName}", GetMySqlDbType(dataType))
                    {
                        Value = DBNull.Value
                    };
                    parameters.Add(parameter);
                }
                reader.Close();

                foreach (var param in parameters)
                {
                    cmd.Parameters.Add(param);
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Stored procedure parametreleri alınamadı: {ex.Message}");
            }
        }

        private MySqlDbType GetMySqlDbType(string dataType)
        {
            return dataType.ToUpper() switch
            {
                "INT" => MySqlDbType.Int32,
                "BIGINT" => MySqlDbType.Int64,
                "VARCHAR" => MySqlDbType.VarChar,
                "TEXT" => MySqlDbType.Text,
                "LONGTEXT" => MySqlDbType.LongText,
                "MEDIUMTEXT" => MySqlDbType.MediumText,
                "DOUBLE" => MySqlDbType.Double,
                "DECIMAL" => MySqlDbType.Decimal,
                "BIT" => MySqlDbType.Bit,
                "DATETIME" => MySqlDbType.DateTime,
                "MEDIUMBLOB" => MySqlDbType.MediumBlob,
                "LONGBLOB"=>MySqlDbType.LongBlob,
                _ => MySqlDbType.VarChar
            };
        }

        private async Task<MySqlConnection> GetConnectionAsync()
        {
            try
            {
                var connection = new MySqlConnection(_connectionString);
                await connection.OpenAsync();
                return connection;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Veritabanı bağlantısı kurulamadı");
                return null;
            }
        }

        private string SerializeDataSet(DataSet dataSet)
        {
            if (dataSet?.Tables?.Count > 0)
            {
                // Birden fazla tablo varsa dictionary olarak döndür
                if (dataSet.Tables.Count > 1)
                {
                    var result = new Dictionary<string, object>();
                    for (int i = 0; i < dataSet.Tables.Count; i++)
                    {
                        result[$"Table{i}"] = ConvertDataTableToList(dataSet.Tables[i]);
                    }
                    return JsonConvert.SerializeObject(result);
                }
                else
                {
                    // Tek tablo varsa direkt list olarak döndür
                    return JsonConvert.SerializeObject(ConvertDataTableToList(dataSet.Tables[0]));
                }
            }

            return JsonConvert.SerializeObject(new { success = true, message = "İşlem başarılı" });
        }

        private List<Dictionary<string, object>> ConvertDataTableToList(DataTable dataTable)
        {
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in dataTable.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn column in dataTable.Columns)
                {
                    dict[column.ColumnName] = row[column] == DBNull.Value ? null : row[column];
                }
                list.Add(dict);
            }

            return list;
        }

        public DataTable ListToDataTable<T>(List<T> list, Type type) where T : class
        {
            var dataTable = new DataTable();
            var properties = type.GetProperties();

            // Kolonları ekle
            foreach (var property in properties)
            {
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            // Satırları ekle
            foreach (var item in list)
            {
                var row = dataTable.NewRow();
                foreach (var property in properties)
                {
                    row[property.Name] = property.GetValue(item) ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}

