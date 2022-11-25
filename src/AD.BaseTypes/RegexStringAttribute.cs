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
    public void Validate(string value, string baseTypeName)
    {
        ArgumentNullException.ThrowIfNull(value, baseTypeName);
        if (!Regex.IsMatch(value, pattern)) throw new ArgumentOutOfRangeException(baseTypeName, value, $"'{baseTypeName}' doesn't match the pattern '{pattern}'.");
    }
}
