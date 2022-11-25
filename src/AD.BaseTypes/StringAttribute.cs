using System.Runtime.CompilerServices;

namespace AD.BaseTypes;

/// <summary>
/// Non-null string wrapper.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class StringAttribute : Attribute, IBaseTypeValidation<string>
{
    /// <exception cref="ArgumentNullException">The parameter <paramref name="value"/> is null.</exception>
    public void Validate(string value, [CallerArgumentExpression(nameof(value))] string? paramName = null) =>
        ArgumentNullException.ThrowIfNull(value, paramName ?? nameof(value));
}
