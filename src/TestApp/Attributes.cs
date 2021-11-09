namespace TestApp
{
    [AttributeUsage(AttributeTargets.Class)]
    class WeekendAttribute : Attribute, IBaseTypeValidation<DateTime>
    {
        public void Validate(DateTime value)
        {
            if (value.DayOfWeek != DayOfWeek.Saturday && value.DayOfWeek != DayOfWeek.Sunday)
                throw new ArgumentOutOfRangeException(nameof(value), value, "must be a Saturday or Sunday");
        }
    }

    [Weekend] public partial record SomeWeekend;

    [AttributeUsage(AttributeTargets.Class)]
    class The90sAttribute : Attribute, IBaseTypeValidation<DateTime>
    {
        public void Validate(DateTime value)
        {
            if (value.Year < 1990 || value.Year > 1999)
                throw new ArgumentOutOfRangeException(nameof(value), value, "must be in the 90s");
        }
    }

    [The90s, Weekend] public partial record SomeWeekendInThe90s;
}
