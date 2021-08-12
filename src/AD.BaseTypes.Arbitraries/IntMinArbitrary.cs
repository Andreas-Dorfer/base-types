using System;

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
        public static IntMinArbitrary<TBaseType> Create<TBaseType>(int min, Func<int, TBaseType> creator) where TBaseType : IBaseType<int> => new(min, creator);
    }

    /// <summary>
    /// Arbitrary for int base types with a minimal value.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class IntMinArbitrary<TBaseType> : IntRangeArbitrary<TBaseType> where TBaseType : IBaseType<int>
    {
        /// <param name="min">The minimal value.</param>
        /// <param name="creator">The base type's creator.</param>
        public IntMinArbitrary(int min, Func<int, TBaseType> creator) : base(min, int.MaxValue, creator)
        { }
    }
}
