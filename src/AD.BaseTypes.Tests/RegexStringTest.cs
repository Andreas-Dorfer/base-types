namespace AD.BaseTypes.Tests;

[RegexString(@"\d\d\w\w")] public partial record MyRegexString;

[TestClass]
public class RegexStringTest : BaseTypeTest<MyRegexString, string>
{
    protected override ExampleArbitrary<MyRegexString, string> Arbitrary => new("00aa", "11bb", "42Ek", "72mI", "99XX");

    [TestMethod, ExpectedException(typeof(ArgumentNullException))]
    public void NoNull() => new MyRegexString(null!);

    [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void NoMatch() => new MyRegexString("x");
}
