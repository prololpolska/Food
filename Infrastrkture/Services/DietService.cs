using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;
using Infrastrkture.DTO;

namespace Infrastrkture.Services
{
    class DietService : IDietService
    {
        public async Task AddDiet(short mealId, int dateId)
        {
            throw new NotImplementedException();
        }

        public async Task AddMeal(string meal)
        {
            throw new NotImplementedException();
        }

        public async Task<Dictionary<int, DateTime>> GetDate()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetDateId(DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MealDayDTO>> GetDiet()
        {
            throw new NotImplementedException();
        }

        public async Task<Dictionary<int, string>> GetMeals()
        {
            throw new NotImplementedException();
        }

        public async Task<MealDayDTO> Map(MealDay mealDay)
        {
            throw new NotImplementedException();
        }
    }
}
