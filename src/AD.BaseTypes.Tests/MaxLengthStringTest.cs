namespace AD.BaseTypes.Tests;

[MaxLengthString(MaxLength)]
public partial record MyMaxLengthString
{
    public const int MaxLength = 10;
}

[TestClass]
public class MaxLengthStringTest : BaseTypeTest<MyMaxLengthString, string>
{
    protected override Arbitrary<MyMaxLengthString> Arbitrary => new MaxLengthStringArbitrary<MyMaxLengthString>(MyMaxLengthString.MaxLength);

    [TestMethod, ExpectedException(typeof(ArgumentNullException))]
    public void NoNull() => new MyMaxLengthString(null!);

    [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TooLong() => new MyMaxLengthString(new('x', MyMaxLengthString.MaxLength + 1));
}
