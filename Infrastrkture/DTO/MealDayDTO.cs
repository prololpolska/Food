using System;

namespace Infrastrkture.DTO
{
    public class MealDayDTO
    {
        public long Id { get; set; }
        public string Day { get; set; }
        public short MealId { get; set; }

        public void SetDay(DateTime date)
        {
            Day = date.DayOfWeek.ToString();
        }
    }
}
