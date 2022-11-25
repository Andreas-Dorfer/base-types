namespace AD.BaseTypes;

/// <summary>
/// Non-empty string.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class NonEmptyStringAttribute : Attribute, IBaseTypeValidation<string>
{
    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is empty.</exception>
    public void Validate(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == string.Empty) throw new ArgumentOutOfRangeException(nameof(value), value, "Parameter must not be empty.");
    }
}
