using MySql.Data.MySqlClient;
using System.Data;

namespace Api.Factory
{
    public class MySqlConnectionFactory:IDbConnectionFactory
    {
        private readonly string _connectionString;

        public MySqlConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MySql");
        }

        public MySqlConnection Create()
        {
            var connection = new MySqlConnection(_connectionString);

            if (connection.State != ConnectionState.Open)
                connection.Open();

            return connection;
        }
    }
}
