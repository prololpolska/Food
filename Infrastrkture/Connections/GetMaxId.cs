using MySql.Data.MySqlClient;

namespace Infrastrkture.Connections
{
    class GetMaxId : BaseConnect
    {
        public int Get(string from)
        {
            int id = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand($"select coalesce(Max(id), 0) as m from {from} Accounts;", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(reader.GetOrdinal("m"));
                    }
                }
                conn.Close();
            }
            return id;
        }
    }
}
