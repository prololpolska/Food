using Infrastrkture.Commands;
using Infrastrkture.Commands.User;
using Infrastrkture.Services;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastrkture.Handlers.User
{
    class GetMealDayHandler : ICommandHandler<GetMeal>
    {
        private readonly IDietService _dietService;
        private readonly IMemoryCache _memoryCache;

        public GetMealDayHandler(IDietService dietService, IMemoryCache memoryCache)
        {
            _dietService = dietService;
            _memoryCache = memoryCache;
        }
        public async Task Handle(GetMeal command)
        {
            var dates = await _dietService.GetDate();
            var diets = await _dietService.GetDiet(dates);
            _memoryCache.Set("dates", dates, TimeSpan.FromMinutes(5));
            _memoryCache.Set("diets", diets, TimeSpan.FromMinutes(5));
        }
    }
}
