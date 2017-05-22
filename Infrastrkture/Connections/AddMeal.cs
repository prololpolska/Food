using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace Infrastrkture.Connections
{
    class AddMeal : BaseConnect
    {
        public async Task<int> Add(string meal)
        {
            int i;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand($"insert into Meals values ((select coalesce(Max(a.id + 1), 1) from Meals as a), \"{meal}\")", conn);
                i = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return i;
        }
    }
}
