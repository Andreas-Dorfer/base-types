using System;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for non-empty GUID base types.
    /// </summary>
    public static class NonEmptyGuidArbitrary
    {
        /// <summary>
        /// Creates an arbitrary.
        /// </summary>
        /// <typeparam name="TBaseType">The base type.</typeparam>
        /// <param name="creator">The base type's creator.</param>
        /// <returns>The arbitrary.</returns>
        public static NonEmptyGuidArbitrary<TBaseType> Create<TBaseType>(Func<Guid, TBaseType> creator) where TBaseType : IBaseType<Guid> => new(creator);
    }

    /// <summary>
    /// Arbitrary for non-empty GUID base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class NonEmptyGuidArbitrary<TBaseType> : GuidArbitrary<TBaseType> where TBaseType : IBaseType<Guid>
    {
        /// <inheritdoc/>
        public NonEmptyGuidArbitrary(Func<Guid, TBaseType> creator) : base(creator)
        { }

        /// <summary>
        /// Filters empty GUIDs.
        /// </summary>
        /// <param name="value">The GUID to check.</param>
        /// <returns>True, if the GUID isn't empty.</returns>
        protected override bool Filter(Guid value) => value != Guid.Empty;
    }
}
