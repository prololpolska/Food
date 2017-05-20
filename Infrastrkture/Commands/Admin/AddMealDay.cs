using System;

namespace Infrastrkture.Commands.Admin
{
    public class AddMealDay : ICommand
    {
        public int MealId { get; set; }
        public DateTime Date { get; set; }
        public AddMealDay(int mealId, DateTime date)
        {
            MealId = mealId;
            Date = date;
        }
    }
}
