using System.Text.RegularExpressions;

namespace AD.BaseTypes
{
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
        public void Validate(string value)
        {
            if (value is null) throw new ArgumentNullException(nameof(value), "Parmeter must not be null");
            if (!Regex.IsMatch(value, pattern)) throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter doesn't match the pattern '{pattern}'.");
        }
    }
}
