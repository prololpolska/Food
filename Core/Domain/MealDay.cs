namespace Core.Domain
{
    public class MealDay
    {
        public long Id { get; private set; }
        public int DateId { get; private set; }
        public short MealId { get; private set; }

        public MealDay(long id, int dateId, short mealId)
        {
            Id = id;
            DateId = dateId;
            MealId = mealId;
        }

        public MealDay(int dateId, short mealId)
        {
            DateId = dateId;
            MealId = mealId;
        }
    }
}
