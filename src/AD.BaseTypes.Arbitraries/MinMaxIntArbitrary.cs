using FsCheck;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for int base types with a range.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class MinMaxIntArbitrary<TBaseType> : IntArbitrary<TBaseType> where TBaseType : IBaseType<int>
    {
        /// <param name="min">The minimal value.</param>
        /// <param name="max">The maximal value.</param>
        /// <exception cref="ArgumentException"><paramref name="max"/> is smaller than <paramref name="min"/>.</exception>
        public MinMaxIntArbitrary(int min, int max)
        {
            if (max < min) throw new ArgumentException("Invalid range.");

            Min = min;
            Max = max;
        }

        /// <summary>
        /// The minimal value.
        /// </summary>
        protected int Min { get; }

        /// <summary>
        /// The maximal value.
        /// </summary>
        protected int Max { get; }

        /// <summary>
        /// Filters too small or too large values.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>True, if the value is valid.</returns>
        protected override bool Filter(int value) => value >= Min && value <= Max;

        /// <inheritdoc/>
        public override Gen<TBaseType> Generator =>
            Gen.Choose(Min, Max).Select(Creator);
    }
}
