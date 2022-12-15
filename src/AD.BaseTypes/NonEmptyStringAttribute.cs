namespace AD.BaseTypes;

/// <summary>
/// Non-empty string.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public sealed class NonEmptyStringAttribute : Attribute, IStaticBaseTypeValidation<string>
{
    /// <param name="value">The value to be validated.</param>
    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is empty.</exception>
    public static void Validate(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == string.Empty) throw new ArgumentOutOfRangeException(nameof(value), value, "Parameter must not be empty.");
    }
}
