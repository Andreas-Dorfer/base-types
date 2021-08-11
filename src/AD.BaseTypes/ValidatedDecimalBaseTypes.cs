using System;

namespace AD.BaseTypes
{
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
