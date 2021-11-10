namespace AD.BaseTypes.Tests;

[Guid] public partial record MyGuid;

[TestClass]
public class GuidTest : BaseTypeTest<MyGuid, Guid>
{
    protected override GuidArbitrary<MyGuid> Arbitrary => new();

    [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void NotEmpty() => new MyGuid(Guid.Empty);
}
