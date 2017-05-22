using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrkture.Connections
{
    class GetDate : BaseConnect
    {
        public async Task<KeyValuePair<int, DateTime>> Get(int id)
        {
            KeyValuePair<int, DateTime> pair;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand($"select * from Days where id = {id}", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pair = new KeyValuePair<int, DateTime>(
                            reader.GetInt32("id"),
                            reader.GetDateTime("dateDay")
                            );
                    }
                }
                conn.Close();
            }
            return pair;
        }

        public async Task<Dictionary<int, DateTime>> Get(DateTime firs, DateTime last)
        {
            Dictionary<int, DateTime> pair = new Dictionary<int, DateTime>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand($"select * from Days where dateDay >= {firs} and id <= {last}", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pair.Add(
                            reader.GetInt32("id"),
                            reader.GetDateTime("dateDay")
                            );
                    }
                }
                conn.Close();
            }
            return pair;
        }
    }
}
