namespace AD.BaseTypes;

/// <summary>
/// Positive Decimal.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public sealed class PositiveDecimalAttribute : Attribute, IStaticBaseTypeValidation<decimal>
{
    /// <param name="value">The value to be validated.</param>
    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is negative.</exception>
    public static void Validate(decimal value)
    {
        if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), value, "Parameter must not be negative.");
    }
}
