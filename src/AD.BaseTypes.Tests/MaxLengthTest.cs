using AD.BaseTypes.Arbitraries;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void NoNull() => new MyMaxLength(null!);

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TooLong() => new MyMaxLength(new('x', MyMaxLength.MaxLength + 1));
    }
}
