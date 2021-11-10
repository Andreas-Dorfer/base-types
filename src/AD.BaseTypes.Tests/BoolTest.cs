namespace AD.BaseTypes.Tests;

[Bool] public partial record MyBool;

[TestClass]
public class BoolTest : BaseTypeTest<MyBool, bool>
{
    protected override BoolArbitrary<MyBool> Arbitrary => new();
}
