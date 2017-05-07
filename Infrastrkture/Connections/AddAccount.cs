using Core.Domain;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrkture.Connections
{
    class AddAccount : BaseConnect
    {
        public void Add(Account p_Account)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand($"insert into Accounts values ({p_Account.Id}, \"{p_Account.FullName}\", \"{p_Account.UserName}\", \"{p_Account.Password}\", \"{p_Account.Email}\", '{p_Account.DietEnd}')", conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
