using AD.BaseTypes.Arbitraries;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AD.BaseTypes.Tests
{
    [MinLength(MinLength)]
    public partial record MyMinLength
    {
        public const int MinLength = 10;
    }

    [TestClass]
    public class MinLengthTest : BaseTypeTest<MyMinLength, string>
    {
        protected override Arbitrary<MyMinLength> Arbitrary => new MinLengthArbitrary<MyMinLength>(MyMinLength.MinLength);

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TooShort() => new MyMinLength(new('x', MyMinLength.MinLength - 1));
    }
}
