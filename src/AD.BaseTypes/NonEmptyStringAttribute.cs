namespace AD.BaseTypes;

/// <summary>
/// Non-empty string.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class NonEmptyStringAttribute : Attribute, IBaseTypeValidation<string>
{
    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is empty.</exception>
    public void Validate(string value, string baseTypeName)
    {
        ArgumentNullException.ThrowIfNull(value, baseTypeName);
        if (value == string.Empty) throw new ArgumentOutOfRangeException(baseTypeName, value, $"'{baseTypeName}' must not be empty.");
    }
}
