using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace Infrastrkture.Connections
{
    class AddMealDay : BaseConnect
    {
        public async Task<int> Add(short mealId, int dateId)
        {
            int i;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand($"insert into MealDayConnector values ((select coalesce(Max(a.id + 1), 1) from MealDayConnector as a), \"{dateId}\", \"{mealId}\")", conn);
                i = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return i;
        }
    }
}
