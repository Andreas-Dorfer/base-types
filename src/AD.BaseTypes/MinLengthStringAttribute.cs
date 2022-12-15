namespace AD.BaseTypes;

/// <summary>
/// String with a minimal length.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public sealed class MinLengthStringAttribute : Attribute, IStaticBaseTypeValidation<string>
{
#pragma warning disable IDE0060 // Remove unused parameter
    /// <param name="minLength">Minimal length.</param>
    public MinLengthStringAttribute(int minLength)
    { }
#pragma warning restore IDE0060 // Remove unused parameter

    /// <param name="value">The value to be validated.</param>
    /// <param name="minLength">Minimal length.</param>
    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is too short.</exception>
    public static void Validate(string value, int minLength) => StringValidation.MinLength(minLength, value);
}
