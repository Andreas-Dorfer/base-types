using AD.BaseTypes.Arbitraries;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.BaseTypes.Tests
{
    [Double] public partial record MyDouble;

    [TestClass]
    public class DoubleTest : BaseTypeTest<MyDouble, double>
    {
        protected override Arbitrary<MyDouble> Arbitrary => new DoubleArbitrary<MyDouble>();

        protected override bool JsonFilter(double value) => double.IsFinite(value);
    }
}
