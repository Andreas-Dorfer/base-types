namespace AD.BaseTypes.Tests
{
    [Int] public partial record MyInt;

    [TestClass]
    public class IntTest : BaseTypeTest<MyInt, int>
    {
        protected override Arbitrary<MyInt> Arbitrary => new IntArbitrary<MyInt>();
    }
}
