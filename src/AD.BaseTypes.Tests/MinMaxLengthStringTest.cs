namespace AD.BaseTypes.Tests;

[MinMaxLengthString(MinLength, MaxLength)]
public partial record MyMinMaxLengthString
{
    public const int MinLength = 10, MaxLength = 20;
}

[TestClass]
public class MinMaxLengthStringTest : BaseTypeTest<MyMinMaxLengthString, string>
{
    protected override MinMaxLengthStringArbitrary<MyMinMaxLengthString> Arbitrary => new(MyMinMaxLengthString.MinLength, MyMinMaxLengthString.MaxLength);

    [TestMethod, ExpectedException(typeof(ArgumentNullException))]
    public void NoNull() => new MyMinMaxLengthString(null!);

    [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TooShort() => new MyMinMaxLengthString(new('x', MyMinMaxLengthString.MinLength - 1));

    [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TooLong() => new MyMinMaxLengthString(new('x', MyMinMaxLengthString.MaxLength + 1));
}
