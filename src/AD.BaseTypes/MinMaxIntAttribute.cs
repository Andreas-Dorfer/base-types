namespace AD.BaseTypes
{
    /// <summary>
    /// Int within a range.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MinMaxIntAttribute : Attribute, IBaseTypeValidation<int>
    {
        readonly int min, max;

        /// <param name="min">Minimal value.</param>
        /// <param name="max">Maximal value.</param>
        public MinMaxIntAttribute(int min, int max)
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
