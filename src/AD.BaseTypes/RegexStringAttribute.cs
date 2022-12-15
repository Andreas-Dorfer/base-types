using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace AD.BaseTypes;

/// <summary>
/// String with a regex constraint.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public sealed class RegexStringAttribute : Attribute, IStaticBaseTypeValidation<string>
{
#pragma warning disable IDE0060 // Remove unused parameter
    /// <param name="pattern">Regex pattern.</param>
    public RegexStringAttribute([StringSyntax(StringSyntaxAttribute.Regex)] string pattern)
    { }
#pragma warning restore IDE0060 // Remove unused parameter

    /// <param name="value">The value to be validated.</param>
    /// <param name="pattern">Regex pattern.</param>
    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> doesn't match.</exception>
    public static void Validate(string value, [StringSyntax(StringSyntaxAttribute.Regex)] string pattern)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (!Regex.IsMatch(value, pattern)) throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter doesn't match the pattern '{pattern}'.");
    }
}
