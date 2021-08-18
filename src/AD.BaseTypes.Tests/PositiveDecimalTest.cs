using AD.BaseTypes.Arbitraries;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.BaseTypes.Tests
{
    [PositiveDecimal] public partial record MyPositiveDecimal;

    [TestClass]
    public class PositiveDecimalTest : BaseTypeTest<MyPositiveDecimal, decimal>
    {
        protected override Arbitrary<MyPositiveDecimal> Arbitrary => new PositiveDecimalArbitrary<MyPositiveDecimal>();
    }
}
