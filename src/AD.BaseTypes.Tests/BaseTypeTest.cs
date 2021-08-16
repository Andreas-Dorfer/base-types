using FsCheck;

namespace AD.BaseTypes.Tests
{
    public abstract class BaseTypeTest<TBaseType, TWrapped> : ValidatedBaseTypeTest<TBaseType, TWrapped> where TBaseType : IBaseType<TWrapped>
    {
        protected override Arbitrary<TWrapped> Arbitrary => Arb.From<TWrapped>();
    }
}
