using System;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for decimal base types.
    /// </summary>
    public static class DecimalArbitrary
    {
        /// <summary>
        /// Creates an arbitrary.
        /// </summary>
        /// <typeparam name="TBaseType">The base type.</typeparam>
        /// <param name="creator">The base type's creator.</param>
        /// <returns>The arbitrary.</returns>
        public static DecimalArbitrary<TBaseType> Create<TBaseType>(Func<decimal, TBaseType> creator) where TBaseType : IBaseType<decimal> => new(creator);
    }

    /// <summary>
    /// Arbitrary for decimal base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class DecimalArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, decimal> where TBaseType : IBaseType<decimal>
    {
        /// <inheritdoc/>
        public DecimalArbitrary(Func<decimal, TBaseType> creator) : base(creator)
        { }
    }
}
