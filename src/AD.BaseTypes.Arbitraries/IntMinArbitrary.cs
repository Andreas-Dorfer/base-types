using FsCheck;
using System;
using System.Linq;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for int base types with a minimal value.
    /// </summary>
    public static class IntMinArbitrary
    {
        /// <summary>
        /// Creates an arbitrary.
        /// </summary>
        /// <typeparam name="TBaseType">The base type.</typeparam>
        /// <param name="min">The minimal value.</param>
        /// <param name="creator">The base type's creator.</param>
        /// <returns>The arbitrary.</returns>
        public static IntMinArbitrary<TBaseType> Create<TBaseType>(int min, Func<int, TBaseType> creator) where TBaseType : IValue<int> => new(min, creator);
    }

    /// <summary>
    /// Arbitrary for int base types with a minimal value.
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public class IntMinArbitrary<TBaseType> : IntArbitrary<TBaseType> where TBaseType : IValue<int>
    {
        /// <param name="min">The minimal value.</param>
        /// <param name="creator">The base type's creator.</param>
        public IntMinArbitrary(int min, Func<int, TBaseType> creator) : base(creator)
        {
            Min = min;
        }

        /// <summary>
        /// The minimal value.
        /// </summary>
        protected int Min { get; }

        /// <summary>
        /// Filters too small values.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>True, if the value is valid.</returns>
        protected override bool Filter(int value) => value >= Min;

        /// <inheritdoc/>
        public override Gen<TBaseType> Generator =>
            Gen.Choose(Min, int.MaxValue).Select(Creator);
    }
}
