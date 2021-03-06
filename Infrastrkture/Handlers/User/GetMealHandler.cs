﻿using System;
using System.Threading.Tasks;
using Infrastrkture.Commands;
using Infrastrkture.Commands.User;
using Infrastrkture.Services;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace Infrastrkture.Handlers.User
{
    class GetMealHandler : ICommandHandler<GetMeal>
    {
        private readonly IDietService _dietService;
        private readonly IMemoryCache _memoryCache;

        public GetMealHandler(IDietService dietService, IMemoryCache memoryCache)
        {
            _dietService = dietService;
            _memoryCache = memoryCache;
        }
        public async Task Handle(GetMeal command)
        {
            var meals = await _dietService.GetMeals();
            _memoryCache.Set("meals", meals, TimeSpan.FromMinutes(5));
        }
    }
}
