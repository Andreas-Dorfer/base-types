namespace AD.BaseTypes.Tests;

[Bool] public partial record MyBool;

[TestClass]
public class BoolTest : BaseTypeTest<MyBool, bool>
{
    protected override BoolArbitrary<MyBool> Arbitrary => new();
}

[Bool] public partial record struct MyBoolStruct;

[TestClass]
public class BoolStructTest : BaseTypeTest<MyBoolStruct, bool>
{
    protected override BoolArbitrary<MyBoolStruct> Arbitrary => new();
}
