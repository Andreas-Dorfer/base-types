using AD.BaseTypes.Arbitraries;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AD.BaseTypes.Tests
{
    [IntMin(Min)]
    public partial record MyIntMin
    {
        public const int Min = -100;
    }

    [TestClass]
    public class IntMinTest : BaseTypeTest<MyIntMin, int>
    {
        protected override Arbitrary<MyIntMin> Arbitrary => new IntMinArbitrary<MyIntMin>(MyIntMin.Min);

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TooSmall() => new MyIntMin(MyIntMin.Min - 1);
    }
}
