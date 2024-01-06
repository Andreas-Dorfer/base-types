namespace AD.BaseTypes.Arbitraries;

/// <summary>
/// Arbitrary for string base types with a maximal length.
/// </summary>
/// <typeparam name="TBaseType"></typeparam>
/// <param name="maxLength">The maximal length.</param>
public class MaxLengthStringArbitrary<TBaseType>(int maxLength) : MinMaxLengthStringArbitrary<TBaseType>(0, maxLength) where TBaseType : IBaseType<TBaseType, string>
{
}
