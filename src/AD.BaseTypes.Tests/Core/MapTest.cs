using AD.BaseTypes.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AD.BaseTypes.Tests.Core
{
    [TestClass]
    public class MapTest
    {
        static int Add1(int i) => i + 1;

        [TestMethod]
        public void Ok() => Assert.AreEqual(Add1(ZeroToTen.Min), new ZeroToTen(ZeroToTen.Min).Map<ZeroToTen, int>(Add1));

        [TestMethod, ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void Error() => new ZeroToTen(ZeroToTen.Max).Map<ZeroToTen, int>(Add1);

        [TestMethod]
        public void TryMapOk()
        {
            if (new ZeroToTen(ZeroToTen.Min).TryMap<ZeroToTen, int>(Add1, out var baseType, out var _))
            {
                Assert.AreEqual(Add1(ZeroToTen.Min), baseType);
            }
            else
            {
                Assert.Fail("true expected");
            }
        }

        [TestMethod]
        public void TryMapError() => Assert.IsFalse(new ZeroToTen(ZeroToTen.Max).TryMap<ZeroToTen, int>(Add1, out var _, out var _));

        [TestMethod]
        public void MapValue() => Assert.AreEqual(Add1(ZeroToTen.Max), new ZeroToTen(ZeroToTen.Max).MapValue(Add1));
    }
}
