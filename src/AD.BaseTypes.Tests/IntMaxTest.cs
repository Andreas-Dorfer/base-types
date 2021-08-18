using AD.BaseTypes.Arbitraries;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.BaseTypes.Tests
{
    [IntMax(Max)]
    public partial record MyIntMax
    {
        public const int Max = 100;
    }

    [TestClass]
    public class IntMaxTest : BaseTypeTest<MyIntMax, int>
    {
        protected override Arbitrary<MyIntMax> Arbitrary => new IntMaxArbitrary<MyIntMax>(MyIntMax.Max);
    }
}
