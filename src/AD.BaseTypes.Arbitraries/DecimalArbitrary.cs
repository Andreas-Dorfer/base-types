namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for decimal base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class DecimalArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, decimal> where TBaseType : IBaseType<decimal>
    { }
}
