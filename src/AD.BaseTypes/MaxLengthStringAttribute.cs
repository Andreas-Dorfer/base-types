namespace AD.BaseTypes;

/// <summary>
/// String with a maximal length.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class MaxLengthStringAttribute : Attribute, IBaseTypeValidation<string>
{
    /// <summary>
    /// Selected max length
    /// </summary>
    public int MaxLength { get; }

    /// <param name="maxLength">Maximal length.</param>
    public MaxLengthStringAttribute(int maxLength)
    {
        this.MaxLength = maxLength;
    }

    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is too long.</exception>
    public void Validate(string value) => StringValidation.MaxLength(MaxLength, value);
}
