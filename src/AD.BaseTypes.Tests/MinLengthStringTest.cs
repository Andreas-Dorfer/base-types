namespace AD.BaseTypes.Tests;

[MinLengthString(MinLength)]
public partial record MyMinLengthString
{
    public const int MinLength = 10;
}

[TestClass]
public class MinLengthStringTest : BaseTypeTest<MyMinLengthString, string>
{
    protected override MinLengthStringArbitrary<MyMinLengthString> Arbitrary => new(MyMinLengthString.MinLength);

    [TestMethod, ExpectedException(typeof(ArgumentNullException))]
    public void NoNull() => new MyMinLengthString(null!);

    [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TooShort() => new MyMinLengthString(new('x', MyMinLengthString.MinLength - 1));
}
