using MySql.Data.MySqlClient;

namespace Infrastrkture.Connections
{
    abstract class BaseConnect
    {
        public string ConnectionString = "server=localhost;user=FoodAdmin;password=1234;database=Food;";
        
        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
