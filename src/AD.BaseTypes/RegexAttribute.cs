using System;
using System.Text.RegularExpressions;

namespace AD.BaseTypes
{
    /// <summary>
    /// String with a regex constraint.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class RegexAttribute : Attribute, IBaseTypeValidation<string>
    {
        readonly string pattern;

        /// <param name="pattern">Regex pattern.</param>
        public RegexAttribute(string pattern)
        {
            this.pattern = pattern;
        }

        /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> doesn't match.</exception>
        public void Validate(string value)
        {
            if (value is null || !Regex.IsMatch(value, pattern)) throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter doesn't match the pattern '{pattern}'.");
        }
    }
}
