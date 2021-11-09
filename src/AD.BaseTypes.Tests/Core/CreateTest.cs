namespace AD.BaseTypes.Tests.Core
{
    [TestClass]
    public class CreateTest
    {
        [TestMethod]
        public void Ok() => BaseType<ZeroToTen, int>.Create(ZeroToTen.Max / 2);

        [TestMethod, ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void Error() => BaseType<ZeroToTen, int>.Create(ZeroToTen.Max + 1);

        [TestMethod]
        public void TryOk() => Assert.IsTrue(BaseType<ZeroToTen, int>.TryCreate(ZeroToTen.Max / 2, out var _, out var _));

        [TestMethod]
        public void TryError() => Assert.IsFalse(BaseType<ZeroToTen, int>.TryCreate(ZeroToTen.Max + 1, out var _, out var _));
    }
}
