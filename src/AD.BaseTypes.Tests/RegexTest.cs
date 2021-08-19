using AD.BaseTypes.Arbitraries;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AD.BaseTypes.Tests
{
    [Regex(@"\d\d\w\w")] public partial record MyRegex;

    [TestClass]
    public class RegexTest : BaseTypeTest<MyRegex, string>
    {
        protected override Arbitrary<MyRegex> Arbitrary => new ExampleArbitrary<MyRegex, string>("00aa", "11bb", "42Ek", "72mI", "99XX");

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void NoNull() => new MyRegex(null!);

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NoMatch() => new MyRegex("x");
    }
}
