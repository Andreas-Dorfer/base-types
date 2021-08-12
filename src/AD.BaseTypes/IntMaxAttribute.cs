using System;

namespace AD.BaseTypes
{
    /// <summary>
    /// Int with a maximal value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class IntMaxAttribute : Attribute, IBaseTypeValidation<int>
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
}
