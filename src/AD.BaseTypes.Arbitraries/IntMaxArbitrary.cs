namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for int base types with a maximal value.
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public class IntMaxArbitrary<TBaseType> : IntRangeArbitrary<TBaseType> where TBaseType : IBaseType<int>
    {
        /// <param name="max">The maximal value.</param>
        public IntMaxArbitrary(int max) : base(int.MinValue, max)
        { }
    }
}
