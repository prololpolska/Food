using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrkture.Connections
{
    class GetMeal : BaseConnect
    {
        public async Task<Dictionary<int, string>> Get()
        {
            Dictionary<int, string> pair = new Dictionary<int, string>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand($"select * from Meals", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pair.Add(
                            reader.GetInt16("id"),
                            reader.GetString("items")
                            );
                    }
                }
                conn.Close();
            }
            return pair;
        }
    }
}
