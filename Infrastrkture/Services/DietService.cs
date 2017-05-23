using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;
using Infrastrkture.DTO;
using Core.Repositories;
using Infrastrkture.Connections;
using AutoMapper;

namespace Infrastrkture.Services
{
    class DietService : IDietService
    {
        private readonly IMealDayRepository _repository;
        private readonly IMapper _mapper;

        public DietService(IMealDayRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddDiet(short mealId, int dateId)
        {
            MealDay mealDay = new MealDay(dateId, mealId);
            if(mealDay == null)
            {
                throw new Exception("Nie poprawne dane");
            }
            await _repository.Add(mealDay);
        }

        public async Task AddMeal(string meal)
        {
            var addMeal = new AddMeal();
            var add = await addMeal.Add(meal);
            if(add == 0)
            {
                throw new Exception("Błąd połączenia z bazą danych");
            }
        }

        public async Task<Dictionary<int, DateTime>> GetDate()
        {
            var getDate = new GetDate();
            Dictionary<int, DateTime> date = await getDate.Get(DateTime.UtcNow.Date, DateTime.UtcNow.Date.AddDays(6));
            return date;
        }

        public async Task<int> GetDateId(DateTime date)
        {
            var getDate = new GetDate();
            var id = await getDate.Get(date);
            if(id == 0)
            {
                var addDate = new AddDate();
                var add = await addDate.Add(date);
                if(add == 0)
                {
                    throw new Exception("Błąd połączenia z bazą danych");
                }
                id = await getDate.Get(date);
            }
            return id;
        }

        public async Task<List<MealDayDTO>> GetDiet()
        {
            var dates = await GetDate();
            var list = new List<MealDayDTO>();
            foreach(var item in dates)
            {
                var mealDay = await _repository.Get(item.Key);
                foreach(var item1 in mealDay)
                {
                    list.Add(await Map(item1, item.Value));
                }
            }
            return list;
        }

        public async Task<Dictionary<int, string>> GetMeals()
        {
            var getMeals = new GetMeal();
            return await getMeals.Get();
        }

        public async Task<MealDayDTO> Map(MealDay mealDay, DateTime date)
        {
            var mealDayDTO = _mapper.Map<MealDay, MealDayDTO>(mealDay);
            mealDayDTO.SetDay(date);
            return mealDayDTO;
        }
    }
}
