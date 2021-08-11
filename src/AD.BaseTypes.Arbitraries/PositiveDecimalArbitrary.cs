using System;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for positive deicmal base types.
    /// </summary>
    public static class PositiveDecimalArbitrary
    {
        /// <summary>
        /// Creates an arbitrary.
        /// </summary>
        /// <typeparam name="TBaseType">The base type.</typeparam>
        /// <param name="creator">The base type's creator.</param>
        /// <returns>The arbitrary.</returns>
        public static PositiveDecimalArbitrary<TBaseType> Create<TBaseType>(Func<decimal, TBaseType> creator) where TBaseType : IValue<decimal> => new(creator);
    }

    /// <summary>
    /// Arbitrary for positive deicmal base types.
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public class PositiveDecimalArbitrary<TBaseType> : DecimalArbitrary<TBaseType> where TBaseType : IValue<decimal>
    {
        /// <inheritdoc/>
        public PositiveDecimalArbitrary(Func<decimal, TBaseType> creator) : base(creator)
        { }

        /// <summary>
        /// Filters negative decimals.
        /// </summary>
        /// <param name="value">The decimal to check.</param>
        /// <returns>True, if the decimal is positive.</returns>
        protected override bool Filter(decimal value) => value >= 0;
    }
}
