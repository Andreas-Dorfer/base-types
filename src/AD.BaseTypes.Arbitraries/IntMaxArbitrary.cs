using FsCheck;
using System;
using System.Linq;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for int base types with a maximal value.
    /// </summary>
    public static class IntMaxArbitrary
    {
        /// <summary>
        /// Creates an arbitrary.
        /// </summary>
        /// <typeparam name="TBaseType">The base type.</typeparam>
        /// <param name="max">The maximal value.</param>
        /// <param name="creator">The base type's creator.</param>
        /// <returns>The arbitrary.</returns>
        public static IntMaxArbitrary<TBaseType> Create<TBaseType>(int max, Func<int, TBaseType> creator) where TBaseType : IValue<int> => new(max, creator);
    }

    /// <summary>
    /// Arbitrary for int base types with a maximal value.
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public class IntMaxArbitrary<TBaseType> : IntArbitrary<TBaseType> where TBaseType : IValue<int>
    {
        /// <param name="max">The maximal value.</param>
        /// <param name="creator">The base type's creator.</param>
        public IntMaxArbitrary(int max, Func<int, TBaseType> creator) : base(creator)
        {
            Max = max;
        }

        /// <summary>
        /// The maximal value.
        /// </summary>
        protected int Max { get; }

        /// <summary>
        /// Filters too small values.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>True, if the value is valid.</returns>
        protected override bool Filter(int value) => value <= Max;

        /// <inheritdoc/>
        public override Gen<TBaseType> Generator =>
            Gen.Choose(int.MinValue, Max).Select(Creator);
    }
}
