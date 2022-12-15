namespace AD.BaseTypes;

/// <summary>
/// String with a maximal length.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public sealed class MaxLengthStringAttribute : Attribute, IStaticBaseTypeValidation<string>
{
#pragma warning disable IDE0060 // Remove unused parameter
    /// <param name="maxLength">Maximal length.</param>
    public MaxLengthStringAttribute(int maxLength)
    { }
#pragma warning restore IDE0060 // Remove unused parameter

    /// <param name="value">The value to be validated.</param>
    /// <param name="maxLength">Maximal length.</param>
    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is too long.</exception>
    public static void Validate(string value, int maxLength) => StringValidation.MaxLength(maxLength, value);
}
