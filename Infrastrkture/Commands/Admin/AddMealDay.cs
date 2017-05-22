using System;

namespace Infrastrkture.Commands.Admin
{
    public class AddMealDay : ICommand
    {
        public short MealId { get; set; }
        public DateTime Date { get; set; }
        public AddMealDay(short mealId, DateTime date)
        {
            MealId = mealId;
            Date = date;
        }
    }
}
