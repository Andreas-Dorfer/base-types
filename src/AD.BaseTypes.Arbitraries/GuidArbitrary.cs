using System;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for GUID base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class GuidArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, Guid> where TBaseType : IBaseType<Guid>
    { }
}
