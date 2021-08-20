using AD.BaseTypes.Arbitraries;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AD.BaseTypes.Tests
{
    [RangeInt(Min, Max)]
    public partial record MyRangeInt
    {
        public const int Min = -100, Max = 100;
    }

    [TestClass]
    public class RangeIntTest : BaseTypeTest<MyRangeInt, int>
    {
        protected override Arbitrary<MyRangeInt> Arbitrary => new RangeIntArbitrary<MyRangeInt>(MyRangeInt.Min, MyRangeInt.Max);

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TooSmall() => new MyRangeInt(MyRangeInt.Min - 1);

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TooLarge() => new MyRangeInt(MyRangeInt.Max + 1);
    }
}
