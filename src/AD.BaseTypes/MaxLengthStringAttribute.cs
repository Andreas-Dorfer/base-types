namespace AD.BaseTypes;

/// <summary>
/// String with a maximal length.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class MaxLengthStringAttribute : Attribute, IBaseTypeValidation<string>
{
    readonly int maxLength;

    /// <param name="maxLength">Maximal length.</param>
    public MaxLengthStringAttribute(int maxLength)
    {
        this.maxLength = maxLength;
    }

    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is too long.</exception>
    public void Validate(string value) => StringValidation.MaxLength(maxLength, value);
}
