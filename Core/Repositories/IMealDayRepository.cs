using Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IMealDayRepository : IRepository
    {
        Task<List<MealDay>> Get(int dateId);
        Task Add(MealDay mealDay);
    }
}
