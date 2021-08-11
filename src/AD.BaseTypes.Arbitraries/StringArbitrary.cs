using System;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for string base types.
    /// </summary>
    public static class StringArbitrary
    {
        /// <summary>
        /// Creates an arbitrary.
        /// </summary>
        /// <typeparam name="TBaseType">The base type.</typeparam>
        /// <param name="creator">The base type's creator.</param>
        /// <returns>The arbitrary.</returns>
        public static StringArbitrary<TBaseType> Create<TBaseType>(Func<string, TBaseType> creator) where TBaseType : IValue<string> => new(creator);
    }

    /// <summary>
    /// Arbitrary for string base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class StringArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, string> where TBaseType : IValue<string>
    {
        /// <inheritdoc/>
        public StringArbitrary(Func<string, TBaseType> creator) : base(creator)
        { }
    }
}
