using System;

namespace AD.BaseTypes
{
    static class IntValidation
    {
        public static void Min(int min, int value)
        {
            if (value < min) throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter must be more than {min}.");
        }

        public static void Max(int max, int value)
        {
            if (value > max) throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter must be less than {max}.");
        }
    }

    /// <summary>
    /// Int with a minimal value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class IntMinAttribute : Attribute, IValidatedBaseType<int>
    {
        readonly int min;

        /// <param name="min">Minimal value.</param>
        public IntMinAttribute(int min)
        {
            this.min = min;
        }

        /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is too small.</exception>
        public void Validate(int value) => IntValidation.Min(min, value);
    }

    /// <summary>
    /// Int with a maximal value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class IntMaxAttribute : Attribute, IValidatedBaseType<int>
    {
        readonly int max;

        /// <param name="max">Maximal value.</param>
        public IntMaxAttribute(int max)
        {
            this.max = max;
        }

        /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is too large.</exception>
        public void Validate(int value) => IntValidation.Max(max, value);
    }

    /// <summary>
    /// Int within a range.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class IntRangeAttribute : Attribute, IValidatedBaseType<int>
    {
        readonly int min, max;

        /// <param name="min">Minimal value.</param>
        /// <param name="max">Maximal value.</param>
        public IntRangeAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is too small or too large.</exception>
        public void Validate(int value)
        {
            IntValidation.Min(min, value);
            IntValidation.Max(max, value);
        }
    }
}
