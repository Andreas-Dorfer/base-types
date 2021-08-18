namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for bool base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class BoolArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, bool> where TBaseType : IBaseType<bool>
    { }
}
