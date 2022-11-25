using System.Runtime.CompilerServices;

namespace AD.BaseTypes;

/// <summary>
/// Non-empty string.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class NonEmptyStringAttribute : Attribute, IBaseTypeValidation<string>
{
    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is empty.</exception>
    public void Validate(string value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
    {
        paramName ??= nameof(value);
        ArgumentNullException.ThrowIfNull(value, paramName);
        if (value == string.Empty) throw new ArgumentOutOfRangeException(paramName, value, $"'{paramName}' must not be empty.");
    }
}
