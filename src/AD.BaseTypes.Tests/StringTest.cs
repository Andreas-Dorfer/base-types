namespace AD.BaseTypes.Tests;

[String] public partial record MyString;

[TestClass]
public class StringTest : BaseTypeTest<MyString, string>
{
    protected override StringArbitrary<MyString> Arbitrary => new();

    [TestMethod, ExpectedException(typeof(ArgumentNullException))]
    public void NoNull() => new MyString(null!);
}
