using System;

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
        public static IntMaxArbitrary<TBaseType> Create<TBaseType>(int max, Func<int, TBaseType> creator) where TBaseType : IBaseType<int> => new(max, creator);
    }

    /// <summary>
    /// Arbitrary for int base types with a maximal value.
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public class IntMaxArbitrary<TBaseType> : IntRangeArbitrary<TBaseType> where TBaseType : IBaseType<int>
    {
        /// <param name="max">The maximal value.</param>
        /// <param name="creator">The base type's creator.</param>
        public IntMaxArbitrary(int max, Func<int, TBaseType> creator) : base(int.MinValue, max, creator)
        { }
    }
}
