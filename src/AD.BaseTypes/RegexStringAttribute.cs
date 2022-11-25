using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AD.BaseTypes;

/// <summary>
/// String with a regex constraint.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class RegexStringAttribute : Attribute, IBaseTypeValidation<string>
{
    readonly string pattern;

    /// <param name="pattern">Regex pattern.</param>
    public RegexStringAttribute(string pattern)
    {
        this.pattern = pattern;
    }

    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> doesn't match.</exception>
    public void Validate(string value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
    {
        paramName ??= nameof(value);
        ArgumentNullException.ThrowIfNull(value, paramName);
        if (!Regex.IsMatch(value, pattern)) throw new ArgumentOutOfRangeException(paramName, value, $"'{paramName}' doesn't match the pattern '{pattern}'.");
    }
}
