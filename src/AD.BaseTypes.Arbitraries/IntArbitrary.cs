namespace AD.BaseTypes.Arbitraries;

/// <summary>
/// Arbitrary for int base types.
/// </summary>
/// <typeparam name="TBaseType">The base type.</typeparam>
public class IntArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, int> where TBaseType : IBaseType<int>
{ }
