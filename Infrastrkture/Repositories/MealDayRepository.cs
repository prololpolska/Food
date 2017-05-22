using Core.Repositories;
using Core.Domain;
using System.Threading.Tasks;
using Infrastrkture.Connections;
using System;

namespace Infrastrkture.Repositories
{
    public class MealDayRepository : IMealDayRepository
    {
        public async Task Add(MealDay mealDay)
        {
            throw new NotImplementedException();
        }

        public async Task<MealDay> Get(DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetId()
        {
            throw new NotImplementedException();
        }
    }
}
