using MySql.Data.MySqlClient;

namespace Infrastrkture.Connections
{
    abstract class BaseConnect
    {
        public string ConnectionString = "server=localhost;user=user;password=user;database=ziemniaki;";
        
        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
