using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace AD.BaseTypes;

/// <summary>
/// String with a regex constraint.
/// </summary>
/// <param name="pattern">Regex pattern.</param>
[AttributeUsage(AttributeTargets.Class)]
#pragma warning disable CS9113 // Parameter is unread.
public sealed class RegexStringAttribute([StringSyntax(StringSyntaxAttribute.Regex)] string pattern) : Attribute, IStaticBaseTypeValidation<string>
#pragma warning restore CS9113 // Parameter is unread.
{
    /// <param name="value">The value to be validated.</param>
    /// <param name="pattern">Regex pattern.</param>
    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> doesn't match.</exception>
    public static void Validate(string value, [StringSyntax(StringSyntaxAttribute.Regex)] string pattern)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (!Regex.IsMatch(value, pattern)) throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter doesn't match the pattern '{pattern}'.");
    }
}
