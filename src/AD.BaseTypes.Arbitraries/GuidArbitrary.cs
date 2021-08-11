using System;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for GUID base types.
    /// </summary>
    public static class GuidArbitrary
    {
        /// <summary>
        /// Creates an arbitrary.
        /// </summary>
        /// <typeparam name="TBaseType">The base type.</typeparam>
        /// <param name="creator">The base type's creator.</param>
        /// <returns>The arbitrary.</returns>
        public static GuidArbitrary<TBaseType> Create<TBaseType>(Func<Guid, TBaseType> creator) where TBaseType : IValue<Guid> => new(creator);
    }

    /// <summary>
    /// Arbitrary for GUID base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class GuidArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, Guid> where TBaseType : IValue<Guid>
    {
        /// <inheritdoc/>
        public GuidArbitrary(Func<Guid, TBaseType> creator) : base(creator)
        { }
    }
}
