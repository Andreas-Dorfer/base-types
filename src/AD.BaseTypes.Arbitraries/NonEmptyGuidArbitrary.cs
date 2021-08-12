using System;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for non-empty GUID base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class NonEmptyGuidArbitrary<TBaseType> : GuidArbitrary<TBaseType> where TBaseType : IBaseType<Guid>
    {
        /// <summary>
        /// Filters empty GUIDs.
        /// </summary>
        /// <param name="value">The GUID to check.</param>
        /// <returns>True, if the GUID isn't empty.</returns>
        protected override bool Filter(Guid value) => value != Guid.Empty;
    }
}
