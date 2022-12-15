namespace AD.BaseTypes;

/// <summary>
/// Non-empty GUID.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class NonEmptyGuidAttribute : Attribute, IStaticBaseTypeValidation<Guid>
{
    /// <param name="value">The value to be validated.</param>
    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is empty.</exception>
    public static void Validate(Guid value)
    {
        if (value == Guid.Empty) throw new ArgumentOutOfRangeException(nameof(value), value, "Parameter must not be empty.");
    }
}
