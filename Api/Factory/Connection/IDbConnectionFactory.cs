using MySql.Data.MySqlClient;

namespace Api.Factory
{
    public interface IDbConnectionFactory
    {
        MySqlConnection Create();
    }
}
