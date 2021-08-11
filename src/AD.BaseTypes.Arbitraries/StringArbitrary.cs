using System;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for string base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class StringArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, string> where TBaseType : IValue<string>
    {
        /// <inheritdoc/>
        public StringArbitrary(Func<string, TBaseType> creator) : base(creator)
        { }

        /// <inheritdoc/>
        public static new StringArbitrary<TBaseType> Create(Func<string, TBaseType> creator) => new(creator);
    }
}
