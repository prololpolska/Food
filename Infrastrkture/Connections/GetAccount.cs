using Core.Domain;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrkture.Connections
{
    class GetAccount : BaseConnect
    {
        public async Task<Account> WhereEmail(string p_Email)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand($"SELECT * FROM Accounts where email = \"{p_Email}\"", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Account()
                        {
                            Id = reader.GetInt32("id"),
                            FullName = reader.GetString("fullName"),
                            UserName = reader.GetString("userName"),
                            DietEnd = reader.GetDateTime("dietEnd"),
                            Password = reader.GetString("paswd"),
                            Email = reader.GetString("email"),
                            Salt = reader.GetString("salt"),
                            Role = reader.GetString("role")
                        };
                    }
                }
            }
            return null;
        }

        public async Task<Account> WhereId(int p_Id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand($"SELECT * FROM Accounts where id = {p_Id}", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Account()
                        {
                            Id = reader.GetInt32("id"),
                            FullName = reader.GetString("fullName"),
                            UserName = reader.GetString("userName"),
                            DietEnd = reader.GetDateTime("dietEnd"),
                            Password = reader.GetString("paswd"),
                            Email = reader.GetString("email"),
                            Salt = reader.GetString("salt"),
                            Role = reader.GetString("role")
                        };
                    }
                }
            }
            return null;
        }
    }
}
