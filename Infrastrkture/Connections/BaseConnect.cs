using MySql.Data.MySqlClient;

namespace Infrastrkture.Connections
{
    abstract class BaseConnect
    {
        public string ConnectionString = "server=localhost;user=root;password=;database=ziemniaki;";
        
        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
