using System;
using System.Text.RegularExpressions;

namespace AD.BaseTypes
{
    /// <summary>
    /// Non-empty GUID.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class NonEmptyGuidAttribute : Attribute, IValidatedBaseType<Guid>
    {
        /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is empty.</exception>
        public void Validate(Guid value)
        {
            if (value == Guid.Empty) throw new ArgumentOutOfRangeException(nameof(value), value, "Parameter must not be empty.");
        }
    }

    /// <summary>
    /// Non-empty string.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class NonEmptyStringAttribute : Attribute, IValidatedBaseType<string>
    {
        /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is empty.</exception>
        public void Validate(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentOutOfRangeException(nameof(value), value, "Parameter must not be empty.");
        }
    }

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
        public void Validate(string value)
        {
            if (value is null || value.Length < minLength) throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter must be at least {minLength} character(s) long.");
        }
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
        public void Validate(string value)
        {
            if (value is null || value.Length > maxLength) throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter must not be no longer than {maxLength} character(s).");
        }
    }

    /// <summary>
    /// String with a minimal and maximal length.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MinMaxLengthAttribute : Attribute, IValidatedBaseType<string>
    {
        readonly int minLength;
        readonly int maxLength;

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
            if (value is null || value.Length < minLength) throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter must be at least {minLength} character(s) long.");
            if (value.Length > maxLength) throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter must not be no longer than {maxLength} character(s).");
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

    /// <summary>
    /// Positive Decimal.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class PositiveDecimalAttribute : Attribute, IValidatedBaseType<decimal>
    {
        /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is negative.</exception>
        public void Validate(decimal value)
        {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), value, "Parameter must not be negative.");
        }
    }
}
