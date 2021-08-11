using System;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for non-empty GUID base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class NonEmptyGuidArbitrary<TBaseType> : GuidArbitrary<TBaseType> where TBaseType : IValue<Guid>
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

        /// <inheritdoc/>
        public static new NonEmptyGuidArbitrary<TBaseType> Create(Func<Guid, TBaseType> creator) => new(creator);
    }
}
