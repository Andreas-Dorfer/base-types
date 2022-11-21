namespace AD.BaseTypes.Tests;

[Double] public partial record MyDouble;

[TestClass]
public class DoubleTest : BaseTypeTest<MyDouble, double>
{
    protected override DoubleArbitrary<MyDouble> Arbitrary => new();

    protected override bool JsonFilter(double value) => double.IsFinite(value);
}

[Double] public readonly partial record struct MyDoubleStruct;

[TestClass]
public class DoubleStrictTest : BaseTypeTest<MyDoubleStruct, double>
{
    protected override DoubleArbitrary<MyDoubleStruct> Arbitrary => new();

    protected override bool JsonFilter(double value) => double.IsFinite(value);
}