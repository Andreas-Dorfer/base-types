using FsCheck;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for decimal base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class DecimalArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, decimal> where TBaseType : IBaseType<decimal>
    {
        /// <inheritdoc/>
        public override Gen<TBaseType> Generator =>
            //the default decimal generator doesn't generate negative values --> invert some values
            Arb.Default.Decimal().Generator.Zip(Arb.Default.Bool().Generator, (value, invert) => invert ? -value : value).Where(Filter).Select(Creator);
    }
}
