namespace AD.BaseTypes;

/// <summary>
/// String with a minimal length.
/// </summary>
/// <param name="minLength">Minimal length.</param>
[AttributeUsage(AttributeTargets.Class)]
#pragma warning disable CS9113 // Parameter is unread.
public sealed class MinLengthStringAttribute(int minLength) : Attribute, IStaticBaseTypeValidation<string>
#pragma warning restore CS9113 // Parameter is unread.
{
    /// <param name="value">The value to be validated.</param>
    /// <param name="minLength">Minimal length.</param>
    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is too short.</exception>
    public static void Validate(string value, int minLength) => StringValidation.MinLength(minLength, value);
}
