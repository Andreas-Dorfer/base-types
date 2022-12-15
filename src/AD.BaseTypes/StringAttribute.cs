namespace AD.BaseTypes;

/// <summary>
/// Non-null string wrapper.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public sealed class StringAttribute : Attribute, IStaticBaseTypeValidation<string>
{
    /// <param name="value">The value to be validated.</param>
    /// <exception cref="ArgumentNullException">The parameter <paramref name="value"/> is null.</exception>
    public static void Validate(string value) => ArgumentNullException.ThrowIfNull(value);
}
