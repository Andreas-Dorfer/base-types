namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for int base types with a minimal value.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class IntMinArbitrary<TBaseType> : IntRangeArbitrary<TBaseType> where TBaseType : IBaseType<int>
    {
        /// <param name="min">The minimal value.</param>
        public IntMinArbitrary(int min) : base(min, int.MaxValue)
        { }
    }
}
