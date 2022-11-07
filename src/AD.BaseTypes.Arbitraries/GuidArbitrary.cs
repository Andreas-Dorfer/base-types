namespace AD.BaseTypes.Arbitraries;

/// <summary>
/// Arbitrary for Guid base types.
/// </summary>
/// <typeparam name="TBaseType">The base type.</typeparam>
public class GuidArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, Guid> where TBaseType : IBaseType<Guid>
{ }
