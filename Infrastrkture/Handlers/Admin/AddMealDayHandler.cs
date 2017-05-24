using System.Threading.Tasks;
using Infrastrkture.Commands;
using Infrastrkture.Commands.Admin;
using Infrastrkture.Services;

namespace Infrastrkture.Handlers.Admin
{
    class AddMealDayHandler : ICommandHandler<AddMealDay>
    {
        private readonly IDietService _dietService;
        public AddMealDayHandler(IDietService dietService)
        {
            _dietService = dietService;
        }
        public async Task Handle(AddMealDay command)
        {
            var DateId = await _dietService.GetDateId(command.Date);
            await _dietService.AddDiet(command.MealId, DateId);
        }
    }
}
