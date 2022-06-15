using System.Runtime.CompilerServices;

namespace AD.BaseTypes;

/// <summary>
/// Non-null string wrapper.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class StringAttribute : Attribute, IBaseTypeValidation<string>
{
    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">The parameter <paramref name="value"/> is null.</exception>
    public void Validate(string value, [CallerArgumentExpression("value")] string name = "")
    {
        if (value is null) throw new ArgumentNullException(name, $"'{name}' must not be null.");
    }
}
