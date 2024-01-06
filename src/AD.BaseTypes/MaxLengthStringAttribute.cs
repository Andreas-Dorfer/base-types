namespace AD.BaseTypes;

/// <summary>
/// String with a maximal length.
/// </summary>
/// <param name="maxLength">Maximal length.</param>
[AttributeUsage(AttributeTargets.Class)]
#pragma warning disable CS9113 // Parameter is unread.
public sealed class MaxLengthStringAttribute(int maxLength) : Attribute, IStaticBaseTypeValidation<string>
#pragma warning restore CS9113 // Parameter is unread.
{
    /// <param name="value">The value to be validated.</param>
    /// <param name="maxLength">Maximal length.</param>
    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is too long.</exception>
    public static void Validate(string value, int maxLength) => StringValidation.MaxLength(maxLength, value);
}
