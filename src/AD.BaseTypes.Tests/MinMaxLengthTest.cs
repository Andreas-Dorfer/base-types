using AD.BaseTypes.Arbitraries;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TooShort() => new MyMinMaxLength(new('x', MyMinMaxLength.MinLength - 1));

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TooLong() => new MyMinMaxLength(new('x', MyMinMaxLength.MaxLength + 1));
    }
}
