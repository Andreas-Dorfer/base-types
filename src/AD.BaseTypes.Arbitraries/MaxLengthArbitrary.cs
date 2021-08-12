namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for string base types with a maximal length.
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public class MaxLengthArbitrary<TBaseType> : MinMaxLengthArbitrary<TBaseType> where TBaseType : IBaseType<string>
    {
        /// <param name="maxLength">The maximal length.</param>
        public MaxLengthArbitrary(int maxLength) : base(0, maxLength)
        { }
    }
}
