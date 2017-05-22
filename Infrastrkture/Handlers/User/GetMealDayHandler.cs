using Infrastrkture.Commands;
using Infrastrkture.Commands.User;
using Infrastrkture.Services;
using Microsoft.Extensions.Caching.Memory;
using System;
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
            throw new NotImplementedException();
        }
    }
}
