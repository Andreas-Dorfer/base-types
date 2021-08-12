using System;

namespace AD.BaseTypes
{
    /// <summary>
    /// Int with a minimal value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class IntMinAttribute : Attribute, IBaseTypeValidation<int>
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
}
