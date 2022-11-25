namespace AD.BaseTypes;

/// <summary>
/// Positive Decimal.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class PositiveDecimalAttribute : Attribute, IBaseTypeValidation<decimal>
{
    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is negative.</exception>
    public void Validate(decimal value, string baseTypeName)
    {
        if (value < 0) throw new ArgumentOutOfRangeException(baseTypeName, value, $"'{baseTypeName}' must not be negative.");
    }
}
