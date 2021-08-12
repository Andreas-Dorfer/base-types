namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for string base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class StringArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, string> where TBaseType : IBaseType<string>
    { }
}
