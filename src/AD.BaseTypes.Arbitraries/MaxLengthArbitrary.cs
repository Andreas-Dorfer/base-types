using System;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for string base types with a maximal length.
    /// </summary>
    public static class MaxLengthArbitrary
    {
        /// <summary>
        /// Creates an arbitrary.
        /// </summary>
        /// <typeparam name="TBaseType">The base type.</typeparam>
        /// <param name="maxLength">The maximal length.</param>
        /// <param name="creator">The base type's creator.</param>
        /// <returns>The arbitrary.</returns>
        public static MaxLengthArbitrary<TBaseType> Create<TBaseType>(int maxLength, Func<string, TBaseType> creator) where TBaseType : IValue<string> => new(maxLength, creator);
    }

    /// <summary>
    /// Arbitrary for string base types with a maximal length.
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public class MaxLengthArbitrary<TBaseType> : MinMaxLengthArbitrary<TBaseType> where TBaseType : IValue<string>
    {
        /// <param name="maxLength">The maximal length.</param>
        /// <param name="creator">The base type's creator.</param>
        public MaxLengthArbitrary(int maxLength, Func<string, TBaseType> creator) : base(0, maxLength, creator)
        { }
    }
}
