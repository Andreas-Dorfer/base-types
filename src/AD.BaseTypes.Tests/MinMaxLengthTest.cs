using AD.BaseTypes.Arbitraries;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.BaseTypes.Tests
{
    [MinMaxLength(MinLength, MaxLength)]
    public partial record MyMinMaxLength
    {
        public const int MinLength = 10, MaxLength = 20;
    }

    [TestClass]
    public class MinMaxLengthTest : BaseTypeTest<MyMinMaxLength, string>
    {
        protected override Arbitrary<MyMinMaxLength> Arbitrary => new MinMaxLengthArbitrary<MyMinMaxLength>(MyMinMaxLength.MinLength, MyMinMaxLength.MaxLength);
    }
}
