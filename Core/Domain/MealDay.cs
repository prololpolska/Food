using System;

namespace Core.Domain
{
    public class MealDay
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public short MealId { get; set; }
    }
}
