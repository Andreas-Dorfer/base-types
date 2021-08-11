using System;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for int base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class IntArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, int> where TBaseType : IValue<int>
    {
        /// <inheritdoc/>
        public IntArbitrary(Func<int, TBaseType> creator) : base(creator)
        { }

        /// <inheritdoc/>
        public static new IntArbitrary<TBaseType> Create(Func<int, TBaseType> creator) => new(creator);
    }
}
