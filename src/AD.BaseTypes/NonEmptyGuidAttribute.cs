using System.Runtime.CompilerServices;

namespace AD.BaseTypes;

/// <summary>
/// Non-empty GUID.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class NonEmptyGuidAttribute : Attribute, IBaseTypeValidation<Guid>
{
    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is empty.</exception>
    public void Validate(Guid value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
    {
        paramName ??= nameof(value);
        if (value == Guid.Empty) throw new ArgumentOutOfRangeException(paramName, value, $"'{paramName}' must not be empty.");
    }
}
