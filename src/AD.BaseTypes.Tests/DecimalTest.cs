namespace AD.BaseTypes.Tests;

[Decimal] public partial record MyDecimal;

[TestClass]
public class DecimalTest : BaseTypeTest<MyDecimal, decimal>
{
    protected override DecimalArbitrary<MyDecimal> Arbitrary => new();
}

[Decimal] public partial record struct MyDecimalStruct;

[TestClass]
public class DecimalStructTest : BaseTypeTest<MyDecimalStruct, decimal>
{
    protected override DecimalArbitrary<MyDecimalStruct> Arbitrary => new();
}
