using AD.BaseTypes.Arbitraries;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.BaseTypes.Tests
{
    [NonEmptyString] public partial record MyNonEmptyString;

    [TestClass]
    public class NonEmptyStringTest : BaseTypeTest<MyNonEmptyString, string>
    {
        protected override Arbitrary<MyNonEmptyString> Arbitrary => new NonEmptyStringArbitrary<MyNonEmptyString>();
    }
}
