namespace AD.BaseTypes.Tests;

[Int] public partial record MyInt;

[TestClass]
public class IntTest : BaseTypeTest<MyInt, int>
{
    protected override IntArbitrary<MyInt> Arbitrary => new();
}


[Int] public partial record struct MyIntStruct;

[TestClass]
public class IntStructTest : BaseTypeTest<MyIntStruct, int>
{
    protected override IntArbitrary<MyIntStruct> Arbitrary => new();
}
