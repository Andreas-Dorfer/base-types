using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace AD.BaseTypes.Tests
{
    [String] public partial record MyString;

    [TestClass]
    public class StringTest : ValidatedBaseTypeTest<MyString, string>
    {
        protected override Arbitrary<string> Arbitrary => Arb.Default.NonNull<string>().Convert(str => str.Item, str => NonNull<string>.NewNonNull(str));

        protected override MyString New(string value) => new(value);

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void NoNull() => new MyString(null);
    }
}
