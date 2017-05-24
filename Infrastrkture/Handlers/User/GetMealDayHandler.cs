using Infrastrkture.Commands;
using Infrastrkture.Commands.User;
using Infrastrkture.Services;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastrkture.Handlers.User
{
    class GetMealDayHandler : ICommandHandler<GetMealDay>
    {
        private readonly IDietService _dietService;
        private readonly IMemoryCache _memoryCache;

        public GetMealDayHandler(IDietService dietService, IMemoryCache memoryCache)
        {
            _dietService = dietService;
            _memoryCache = memoryCache;
        }
        public async Task Handle(GetMealDay command)
        {
            var dates = await _dietService.GetDate();
            var diets = _dietService.GetDiet(dates);
            var dates2 = _dietService.Map(dates);

            _memoryCache.Set("dates", await dates2, TimeSpan.FromMinutes(5));
            _memoryCache.Set("diets", await diets, TimeSpan.FromMinutes(5));
        }
    }
}
