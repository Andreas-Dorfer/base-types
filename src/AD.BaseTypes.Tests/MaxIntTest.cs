using AD.BaseTypes.Arbitraries;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AD.BaseTypes.Tests
{
    [MaxInt(Max)]
    public partial record MyMaxInt
    {
        public const int Max = 100;
    }

    [TestClass]
    public class MaxIntTest : BaseTypeTest<MyMaxInt, int>
    {
        protected override Arbitrary<MyMaxInt> Arbitrary => new MaxIntArbitrary<MyMaxInt>(MyMaxInt.Max);

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TooLarge() => new MyMaxInt(MyMaxInt.Max + 1);
    }
}
