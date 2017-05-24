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
        Task<Dictionary<short, string>> GetMeals();
        Task<Dictionary<int, DateTime>> GetDate();
        Task<int> GetDateId(DateTime date);
        Task AddDiet(short mealId, int dateId);
        Task<List<MealDayDTO>> GetDiet(Dictionary<int, DateTime> p_dates);
        Task<MealDayDTO> Map(MealDay mealDay);
        Task<Dictionary<int, string>> Map(Dictionary<int, DateTime> date);
    }
}
