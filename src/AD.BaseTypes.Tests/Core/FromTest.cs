namespace AD.BaseTypes.Tests.Core;

[TestClass]
public class FromTest
{
    [TestMethod]
    public void Ok() => ZeroToTen.From(ZeroToTen.Max / 2);

    [TestMethod, ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
    public void Error() => ZeroToTen.From(ZeroToTen.Max + 1);

    [TestMethod]
    public void TryOk() => Assert.IsTrue(ZeroToTen.TryFrom(ZeroToTen.Max / 2, out var _, out var _));

    [TestMethod]
    public void TryError() => Assert.IsFalse(ZeroToTen.TryFrom(ZeroToTen.Max + 1, out var _, out var _));
}
