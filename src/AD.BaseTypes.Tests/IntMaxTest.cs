using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AD.BaseTypes.Tests
{
    [IntMax(Max)]
    public partial record MyIntMax
    {
        public const int Max = 100;
    }

    [TestClass]
    public class IntMaxTest : ValidatedBaseTypeTest<MyIntMax, int>
    {
        protected override Arbitrary<int> Arbitrary => Arb.From(Gen.Choose(int.MinValue, MyIntMax.Max), value => Arb.Shrink(value).Where(_ => _ <= MyIntMax.Max));

        protected override MyIntMax New(int value) => new(value);

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MoreThanMax() => new MyIntMax(MyIntMax.Max + 1);
    }
}
