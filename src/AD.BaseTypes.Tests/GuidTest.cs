using AD.BaseTypes.Arbitraries;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AD.BaseTypes.Tests
{
    [Guid] public partial record MyGuid;

    [TestClass]
    public class GuidTest : BaseTypeTest<MyGuid, Guid>
    {
        protected override Arbitrary<MyGuid> Arbitrary => new GuidArbitrary<MyGuid>();
    }
}
