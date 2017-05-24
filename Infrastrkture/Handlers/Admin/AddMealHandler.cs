using Infrastrkture.Commands;
using Infrastrkture.Commands.Admin;
using Infrastrkture.Handlers.User;
using Infrastrkture.Services;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastrkture.Handlers.Admin
{
    class AddMealHandler : ICommandHandler<AddMeal>
    {
        private readonly IDietService _dietService;
        private readonly IMemoryCache _memoryCache;
        public AddMealHandler(IDietService dietService, IMemoryCache memoryCache)
        {
            _dietService = dietService;
            _memoryCache = memoryCache;
        }
        public async Task Handle(AddMeal command)
        {
            await _dietService.AddMeal(command.Meal);
            var add = new GetMealHandler(_dietService, _memoryCache);
            await add.Handle(null);
        }
    }
}
