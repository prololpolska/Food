using Core.Domain;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastrkture.Connections
{
    class GetMealDay : BaseConnect
    {
        public async Task<List<MealDay>> Get(int dateId)
        {
            List<MealDay> mealDay = null;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand($"select * from MealDayConnector where dayId = {dateId}", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mealDay.Add(new MealDay(
                            reader.GetInt64("id"),
                            reader.GetInt32("dayId"),
                            reader.GetInt16("mealId")
                            ));
                    }
                }
                conn.Close();
            }
            return mealDay;
        }
    }
}
