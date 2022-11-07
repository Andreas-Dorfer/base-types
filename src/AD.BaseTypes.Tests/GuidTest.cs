namespace AD.BaseTypes.Tests;

[Guid] public partial record MyGuid;

[TestClass]
public class GuidTest : BaseTypeTest<MyGuid, Guid>
{
    protected override GuidArbitrary<MyGuid> Arbitrary => new();
}

[Guid] public partial record struct MyGuidStruct;

[TestClass]
public class GuidStructTest : BaseTypeTest<MyGuidStruct, Guid>
{
    protected override GuidArbitrary<MyGuidStruct> Arbitrary => new();
}
