namespace AD.BaseTypes;

/// <summary>
/// Non-null string wrapper.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class StringAttribute : Attribute, IBaseTypeValidation<string>
{
    /// <exception cref="ArgumentNullException">The parameter <paramref name="value"/> is null.</exception>
    public void Validate(string value, string baseTypeName) => ArgumentNullException.ThrowIfNull(value, baseTypeName);
}
