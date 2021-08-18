using AD.BaseTypes.Arbitraries;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.BaseTypes.Tests
{
    [IntRange(Min, Max)]
    public partial record MyIntRange
    {
        public const int Min = -100, Max = 100;
    }

    [TestClass]
    public class IntRangeTest : BaseTypeTest<MyIntRange, int>
    {
        protected override Arbitrary<MyIntRange> Arbitrary => new IntRangeArbitrary<MyIntRange>(MyIntRange.Min, MyIntRange.Max);
    }
}
