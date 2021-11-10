namespace AD.BaseTypes.Tests;

[Decimal] public partial record MyDecimal;

[TestClass]
public class DecimalTest : BaseTypeTest<MyDecimal, decimal>
{
    protected override DecimalArbitrary<MyDecimal> Arbitrary => new();
}
