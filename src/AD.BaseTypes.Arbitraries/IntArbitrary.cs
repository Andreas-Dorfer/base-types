using System;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for int base types.
    /// </summary>
    public static class IntArbitrary
    {
        /// <summary>
        /// Creates an arbitrary.
        /// </summary>
        /// <typeparam name="TBaseType">The base type.</typeparam>
        /// <param name="creator">The base type's creator.</param>
        /// <returns>The arbitrary.</returns>
        public static IntArbitrary<TBaseType> Create<TBaseType>(Func<int, TBaseType> creator) where TBaseType : IBaseType<int> => new(creator);
    }

    /// <summary>
    /// Arbitrary for int base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class IntArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, int> where TBaseType : IBaseType<int>
    {
        /// <inheritdoc/>
        public IntArbitrary(Func<int, TBaseType> creator) : base(creator)
        { }
    }
}
