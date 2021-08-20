using AD.BaseTypes.Arbitraries;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AD.BaseTypes.Tests
{
    [MinLengthString(MinLength)]
    public partial record MyMinLengthString
    {
        public const int MinLength = 10;
    }

    [TestClass]
    public class MinLengthStringTest : BaseTypeTest<MyMinLengthString, string>
    {
        protected override Arbitrary<MyMinLengthString> Arbitrary => new MinLengthStringArbitrary<MyMinLengthString>(MyMinLengthString.MinLength);

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void NoNull() => new MyMinLengthString(null!);

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TooShort() => new MyMinLengthString(new('x', MyMinLengthString.MinLength - 1));
    }
}
