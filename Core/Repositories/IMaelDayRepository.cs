using Core.Domain;
using System;
using System.Threading.Tasks;

namespace Core.Repositories
{
    interface IMaelDayRepository : IRepository
    {
        Task<MealDay> Get(DateTime date);
        Task Add(MealDay mealDay);
        Task<int> GetId();
    }
}
