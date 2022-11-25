using System.Runtime.CompilerServices;

namespace AD.BaseTypes;

/// <summary>
/// Positive Decimal.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class PositiveDecimalAttribute : Attribute, IBaseTypeValidation<decimal>
{
    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is negative.</exception>
    public void Validate(decimal value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
    {
        paramName ??= nameof(value);
        if (value < 0) throw new ArgumentOutOfRangeException(paramName, value, $"'{paramName}' must not be negative.");
    }
}
