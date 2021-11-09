using AD.BaseTypes.Arbitraries;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.BaseTypes.Tests
{
    [MinMaxInt(Min, Max)]
    public partial record MyMinMaxInt
    {
        public const int Min = -100, Max = 100;
    }

    [TestClass]
    public class MinMaxIntTest : BaseTypeTest<MyMinMaxInt, int>
    {
        protected override Arbitrary<MyMinMaxInt> Arbitrary => new MinMaxIntArbitrary<MyMinMaxInt>(MyMinMaxInt.Min, MyMinMaxInt.Max);

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TooSmall() => new MyMinMaxInt(MyMinMaxInt.Min - 1);

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TooLarge() => new MyMinMaxInt(MyMinMaxInt.Max + 1);
    }
}
