namespace AD.BaseTypes.Tests;

[NonNullString] public partial record MyString;

[TestClass]
public class NonNullStringTest : BaseTypeTest<MyString, string>
{
    protected override NonNullStringArbitrary<MyString> Arbitrary => new();

    [TestMethod, ExpectedException(typeof(ArgumentNullException))]
    public void NoNull() => new MyString(null!);
}
