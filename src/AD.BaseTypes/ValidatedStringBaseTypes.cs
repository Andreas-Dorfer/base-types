using System;
using System.Text.RegularExpressions;

namespace AD.BaseTypes
{
    /// <summary>
    /// String with a minimal length.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MinLengthAttribute : Attribute, IValidatedBaseType<string>
    {
        readonly int minLength;

        /// <param name="minLength">Minimal length.</param>
        public MinLengthAttribute(int minLength)
        {
            this.minLength = minLength;
        }

        /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is too short.</exception>
        public void Validate(string value) => StringValidation.MinLength(minLength, value);
    }

    /// <summary>
    /// String with a maximal length.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MaxLengthAttribute : Attribute, IValidatedBaseType<string>
    {
        readonly int maxLength;

        /// <param name="maxLength">Maximal length.</param>
        public MaxLengthAttribute(int maxLength)
        {
            this.maxLength = maxLength;
        }

        /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is too long.</exception>
        public void Validate(string value) => StringValidation.MaxLength(maxLength, value);
    }

    /// <summary>
    /// String with a minimal and maximal length.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MinMaxLengthAttribute : Attribute, IValidatedBaseType<string>
    {
        readonly int minLength, maxLength;

        /// <param name="minLength">Minimal length.</param>
        /// <param name="maxLength">Maximal length.</param>
        public MinMaxLengthAttribute(int minLength, int maxLength)
        {
            this.minLength = minLength;
            this.maxLength = maxLength;
        }

        /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is too short or too long.</exception>
        public void Validate(string value)
        {
            StringValidation.MinLength(minLength, value);
            StringValidation.MaxLength(maxLength, value);
        }
    }

    /// <summary>
    /// String with a regex constraint.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class RegexAttribute : Attribute, IValidatedBaseType<string>
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
