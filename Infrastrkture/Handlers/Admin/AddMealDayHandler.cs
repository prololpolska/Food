using System.Threading.Tasks;
using Infrastrkture.Commands;
using Infrastrkture.Commands.Admin;
using Infrastrkture.Services;
using Infrastrkture.Connections;

namespace Infrastrkture.Handlers.Admin
{
    class AddMealDayHandler : ICommandHandler<Commands.Admin.AddMealDay>
    {
        private readonly IDietService _dietService;
        public AddMealDayHandler(IDietService dietService)
        {
            _dietService = dietService;
        }
        public async Task Handle(Commands.Admin.AddMealDay command)
        {
            var DateId = _dietService.GetDateId(command.Date);
            await _dietService.AddDiet(command.MealId, await DateId);
        }
    }
}
