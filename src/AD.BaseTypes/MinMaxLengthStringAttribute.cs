namespace AD.BaseTypes;

/// <summary>
/// String with a minimal and maximal length.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class MinMaxLengthStringAttribute : Attribute, IBaseTypeValidation<string>
{
    /// <summary>
    /// Selected min length
    /// </summary>
    public int MinLength { get; }
    
    /// <summary>
    /// Selected max length
    /// </summary>
    public int MaxLength { get; }

    /// <param name="minLength">Minimal length.</param>
    /// <param name="maxLength">Maximal length.</param>
    public MinMaxLengthStringAttribute(int minLength, int maxLength)
    {
        this.MinLength = minLength;
        this.MaxLength = maxLength;
    }

    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is too short or too long.</exception>
    public void Validate(string value)
    {
        StringValidation.MinLength(MinLength, value);
        StringValidation.MaxLength(MaxLength, value);
    }
}
