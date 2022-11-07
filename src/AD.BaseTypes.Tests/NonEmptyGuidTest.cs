namespace AD.BaseTypes.Tests;

[NonEmptyGuid] public partial record MyNonEmptyGuid;

[TestClass]
public class NonEmptyGuidTest : BaseTypeTest<MyNonEmptyGuid, Guid>
{
    protected override NonEmptyGuidArbitrary<MyNonEmptyGuid> Arbitrary => new();

    [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void NotEmpty() => new MyNonEmptyGuid(Guid.Empty);
}
