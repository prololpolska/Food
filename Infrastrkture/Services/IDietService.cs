using Core.Domain;
using Infrastrkture.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastrkture.Services
{
    interface IDietService : IService
    {
        Task AddMeal(string meal);
        Task<Dictionary<int, string>> GetMeals();
        Task<Dictionary<int, DateTime>> GetDate();
        Task<int> GetDateId(DateTime date);
        Task AddDiet(short mealId, int dateId);
        Task<List<MealDayDTO>> GetDiet();
        Task<MealDayDTO> Map(MealDay mealDay);
    }
}
