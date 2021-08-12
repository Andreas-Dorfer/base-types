namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for double base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class DoubleArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, double> where TBaseType : IBaseType<double>
    { }
}
