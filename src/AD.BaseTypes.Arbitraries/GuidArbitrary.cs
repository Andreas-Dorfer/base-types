using System;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for GUID base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class GuidArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, Guid> where TBaseType : IValue<Guid>
    {
        /// <inheritdoc/>
        public GuidArbitrary(Func<Guid, TBaseType> creator) : base(creator)
        { }

        /// <inheritdoc/>
        public static new GuidArbitrary<TBaseType> Create(Func<Guid, TBaseType> creator) => new(creator);
    }
}
