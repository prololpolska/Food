namespace Infrastrkture.Commands.Admin
{
    public class AddMeal : ICommand
    {
        public string Meal { get; set; }

        public AddMeal(string meal)
        {
            Meal = meal;
        }
    }
}
