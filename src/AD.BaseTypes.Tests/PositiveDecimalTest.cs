namespace AD.BaseTypes.Tests
{
    [PositiveDecimal] public partial record MyPositiveDecimal;

    [TestClass]
    public class PositiveDecimalTest : BaseTypeTest<MyPositiveDecimal, decimal>
    {
        protected override Arbitrary<MyPositiveDecimal> Arbitrary => new PositiveDecimalArbitrary<MyPositiveDecimal>();

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NotNegative() => new MyPositiveDecimal(-1);
    }
}
