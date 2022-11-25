namespace AD.BaseTypes;

/// <summary>
/// Non-empty GUID.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class NonEmptyGuidAttribute : Attribute, IBaseTypeValidation<Guid>
{
    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is empty.</exception>
    public void Validate(Guid value, string baseTypeName)
    {
        if (value == Guid.Empty) throw new ArgumentOutOfRangeException(baseTypeName, value, $"'{baseTypeName}' must not be empty.");
    }
}
