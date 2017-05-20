using Core.Domain;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace Infrastrkture.Connections
{
    class AddAccount : BaseConnect
    {
        public async Task<int> Add(Account p_Account)
        {
            int i;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand($"insert into Accounts values ({p_Account.Id}, \"{p_Account.FullName}\", \"{p_Account.UserName}\", \"{p_Account.Password}\", \"{p_Account.Email}\", \"{p_Account.Salt}\", \"{p_Account.Role}\", '{p_Account.DietEnd}')", conn);
                i = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return i;
        }
    }
}
