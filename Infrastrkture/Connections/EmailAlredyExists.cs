using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace Infrastrkture.Connections
{
    class EmailAlredyExists : BaseConnect
    {
        public async Task<bool> Exist(string p_Email)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand($"SELECT count(id) as item FROM Accounts where email = \"{p_Email}\"", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.GetInt32("item") > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
