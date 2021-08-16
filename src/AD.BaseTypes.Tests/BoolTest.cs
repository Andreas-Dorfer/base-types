using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.BaseTypes.Tests
{
    [Bool] public partial record MyBool;

    [TestClass]
    public class BoolTest : BaseTypeTest<MyBool, bool>
    {
        protected override MyBool New(bool value) => new(value);
    }
}
