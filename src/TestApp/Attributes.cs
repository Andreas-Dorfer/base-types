using System.Runtime.CompilerServices;

namespace TestApp;

[AttributeUsage(AttributeTargets.Class)]
class WeekendAttribute : Attribute, IBaseTypeValidation<DateTime>
{
    public void Validate(DateTime value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
    {
        paramName ??= nameof(value);
        if (value.DayOfWeek != DayOfWeek.Saturday && value.DayOfWeek != DayOfWeek.Sunday)
            throw new ArgumentOutOfRangeException(paramName, value, $"'{paramName}' must be a Saturday or Sunday.");
    }
}

[Weekend] public partial record SomeWeekend;

[AttributeUsage(AttributeTargets.Class)]
class The90sAttribute : Attribute, IBaseTypeValidation<DateTime>
{
    public void Validate(DateTime value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
    {
        paramName ??= nameof(value);
        if (value.Year < 1990 || value.Year > 1999)
            throw new ArgumentOutOfRangeException(paramName, value, $"'{paramName}' must be in the 90s.");
    }
}

[The90s, Weekend] public partial record SomeWeekendInThe90s;
