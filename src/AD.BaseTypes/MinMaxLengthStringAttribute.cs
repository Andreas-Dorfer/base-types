namespace AD.BaseTypes;

/// <summary>
/// String with a minimal and maximal length.
/// </summary>
/// <param name="minLength">Minimal length.</param>
/// <param name="maxLength">Maximal length.</param>
[AttributeUsage(AttributeTargets.Class)]
#pragma warning disable CS9113 // Parameter is unread.
public sealed class MinMaxLengthStringAttribute(int minLength, int maxLength) : Attribute, IStaticBaseTypeValidation<string>
#pragma warning restore CS9113 // Parameter is unread.
{
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
