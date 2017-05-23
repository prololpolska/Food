using Core.Repositories;
using Core.Domain;
using System.Threading.Tasks;
using Infrastrkture.Connections;
using System;
using System.Collections.Generic;

namespace Infrastrkture.Repositories
{
    public class MealDayRepository : IMealDayRepository
    {
        public async Task Add(MealDay mealDay)
        {
            var addMealDay = new AddMealDay();
            var add = await addMealDay.Add(mealDay.MealId, mealDay.DateId);
            if(add == 0)
            {
                throw new Exception("Błąd połączenia z bazą danych");
            }
        }

        public async Task<List<MealDay>> Get(int dateId)
        {
            var getMealDay = new GetMealDay();
            return await getMealDay.Get(dateId);
        }
    }
}
