using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;

namespace Infrastrkture.Connections
{
    class AddDate : BaseConnect
    {
        public async Task<int> Add(DateTime date)
        {
            int i;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand($"insert into Days values ((select coalesce(Max(a.id + 1), 1) from Days as a), '{date}')", conn);
                i = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return i;
        }
    }
}
