using MySql.Data.MySqlClient;

namespace Infrastrkture.Connections
{
    class GetMaxId : BaseConnect
    {
        public int Get()
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("select Max(id) as m from Accounts;", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return reader.GetInt32(reader.GetOrdinal("m"));
                    }
                }
            }
            return 0;
        }
    }
}
