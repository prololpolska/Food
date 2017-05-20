using Infrastrkture.Commands;
using Infrastrkture.Commands.Admin;
using Infrastrkture.Services;
using System.Threading.Tasks;

namespace Infrastrkture.Handlers.Admin
{
    class AddMealHandler : ICommandHandler<AddMeal>
    {
        private readonly IDietService _dietService;
        public AddMealHandler(IDietService dietService)
        {
            _dietService = dietService;
        }
        public async Task Handle(AddMeal command)
        {
            await _dietService.AddMeal(command.Meal);
        }
    }
}
