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
        protected override Arbitrary<decimal> WrappedArb()
        {
            //the default decimal generator doesn't generate negative values --> invert some values
            var arb = Arb.Default.Decimal();
            return Arb.From(arb.Generator.Zip(Arb.Default.Bool().Generator, (value, invert) => invert ? -value : value), arb.Shrinker);
        }
    }
}
