namespace AD.BaseTypes.Tests;

[NonEmptyString] public partial record MyNonEmptyString;

[TestClass]
public class NonEmptyStringTest : BaseTypeTest<MyNonEmptyString, string>
{
    protected override NonEmptyStringArbitrary<MyNonEmptyString> Arbitrary => new();

    [TestMethod, ExpectedException(typeof(ArgumentNullException))]
    public void NoNull() => new MyNonEmptyString(null!);

    [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void NotEmpty() => new MyNonEmptyString("");
}
