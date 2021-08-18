using FsCheck;
using System;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for int base types with a maximal value.
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public class IntMaxArbitrary<TBaseType> : IntArbitrary<TBaseType> where TBaseType : IBaseType<int>
    {
        /// <param name="max">The maximal value.</param>
        public IntMaxArbitrary(int max)
        {
            Max = max;
        }

        /// <summary>
        /// The maximal value.
        /// </summary>
        protected int Max { get; }

        /// <summary>
        /// Filters too large values.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>True, if the value is valid.</returns>
        protected override bool Filter(int value) => value <= Max;

        /// <inheritdoc/>
        public override Gen<TBaseType> Generator => Gen.Sized(i =>
        {
            var maxSub = Max < 0 ? int.MaxValue + Max + 1 : int.MaxValue;
            return Gen.Choose(Max - Math.Min(i, maxSub), Max);
        }).Select(Creator);
    }
}
