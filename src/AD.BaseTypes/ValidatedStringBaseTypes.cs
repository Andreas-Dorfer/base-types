﻿using System;
using System.Text.RegularExpressions;

namespace AD.BaseTypes
{
    static class StringValidation
    {
        public static void MinLength(int minLength, string value)
        {
            if (value is null || value.Length < minLength) throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter must be at least {minLength} character(s) long.");
        }

        public static void MaxLength(int maxLength, string value)
        {
            if (value is null || value.Length > maxLength) throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter must not be no longer than {maxLength} character(s).");
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