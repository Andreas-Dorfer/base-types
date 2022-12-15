namespace AD.BaseTypes;

/// <summary>
/// String with a minimal and maximal length.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public sealed class MinMaxLengthStringAttribute : Attribute, IStaticBaseTypeValidation<string>
{
#pragma warning disable IDE0060 // Remove unused parameter
    /// <param name="minLength">Minimal length.</param>
    /// <param name="maxLength">Maximal length.</param>
    public MinMaxLengthStringAttribute(int minLength, int maxLength)
    { }
#pragma warning restore IDE0060 // Remove unused parameter

    /// <param name="value">The value to be validated.</param>
    /// <param name="minLength">Minimal length.</param>
    /// <param name="maxLength">Maximal length.</param>
    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is too short or too long.</exception>
    public static void Validate(string value, int minLength, int maxLength)
    {
        StringValidation.MinLength(minLength, value);
        StringValidation.MaxLength(maxLength, value);
    }
}
