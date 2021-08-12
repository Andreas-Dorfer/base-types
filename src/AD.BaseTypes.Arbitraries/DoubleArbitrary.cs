using System;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for double base types.
    /// </summary>
    public static class DoubleArbitrary
    {
        /// <summary>
        /// Creates an arbitrary.
        /// </summary>
        /// <typeparam name="TBaseType">The base type.</typeparam>
        /// <param name="creator">The base type's creator.</param>
        /// <returns>The arbitrary.</returns>
        public static DoubleArbitrary<TBaseType> Create<TBaseType>(Func<double, TBaseType> creator) where TBaseType : IBaseType<double> => new(creator);
    }

    /// <summary>
    /// Arbitrary for double base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class DoubleArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, double> where TBaseType : IBaseType<double>
    {
        /// <inheritdoc/>
        public DoubleArbitrary(Func<double, TBaseType> creator) : base(creator)
        { }
    }
}
