using AD.BaseTypes.Arbitraries;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.BaseTypes.Tests
{
    [String] public partial record MyString;

    [TestClass]
    public class StringTest : BaseTypeTest<MyString, string>
    {
        protected override Arbitrary<MyString> Arbitrary => new StringArbitrary<MyString>();

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void NoNull() => new MyString(null!);
    }
}
