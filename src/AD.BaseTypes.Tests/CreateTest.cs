using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AD.BaseTypes.Tests
{
    [IntRange(Min, Max)]
    public partial record ZeroToTen
    {
        public const int Min = 0, Max = 10;
    }

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
