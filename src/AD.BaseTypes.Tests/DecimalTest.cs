namespace AD.BaseTypes.Tests;

[Decimal] public partial record MyDecimal;

[TestClass]
public class DecimalTest : BaseTypeTest<MyDecimal, decimal>
{
    protected override Arbitrary<MyDecimal> Arbitrary => new DecimalArbitrary<MyDecimal>();
}
