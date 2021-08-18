using AD.BaseTypes.Arbitraries;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.BaseTypes.Tests
{
    [MaxLength(MaxLength)]
    public partial record MyMaxLength
    {
        public const int MaxLength = 10;
    }

    [TestClass]
    public class MaxLengthTest : BaseTypeTest<MyMaxLength, string>
    {
        protected override Arbitrary<MyMaxLength> Arbitrary => new MaxLengthArbitrary<MyMaxLength>(MyMaxLength.MaxLength);
    }
}
