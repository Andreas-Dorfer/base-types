using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AD.BaseTypes.Tests
{
    [IntRange(Min, Max)]
    public partial record MyIntRange
    {
        public const int Min = -100, Max = 100;
    }

    //[TestClass]
    //public class IntRangeTest : ValidatedBaseTypeTest<MyIntRange, int>
    //{
    //    protected override Arbitrary<int> Arbitrary => Arb.From(Gen.Choose(MyIntRange.Min, MyIntRange.Max), value => Arb.Shrink(value).Where(_ => _ >= MyIntRange.Min && _ <= MyIntRange.Max));

    //    protected override MyIntRange New(int value) => new(value);
    //}
}
