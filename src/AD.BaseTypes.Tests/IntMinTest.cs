using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AD.BaseTypes.Tests
{
    [IntMin(Min)]
    public partial record MyIntMin
    {
        public const int Min = -100;
    }

    [TestClass]
    public class IntMinTest : ValidatedBaseTypeTest<MyIntMin, int>
    {
        protected override Arbitrary<int> Arbitrary => Arb.From(Gen.Choose(MyIntMin.Min, int.MaxValue), value => Arb.Shrink(value).Where(_ => _ >= MyIntMin.Min));

        protected override MyIntMin New(int value) => new(value);

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LessThanMin() => new MyIntMin(MyIntMin.Min - 1);
    }
}
