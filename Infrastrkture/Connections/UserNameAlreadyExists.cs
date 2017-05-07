using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace Infrastrkture.Connections
{
    class UserNameAlreadyExists : BaseConnect
    {
        public async Task<bool> Exist(string p_UserName)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand($"SELECT count(id) as item FROM Accounts where userName = \"{p_UserName}\"", conn);
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
