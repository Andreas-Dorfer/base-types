using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AD.BaseTypes.Tests
{
    [Guid] public partial record MyGuid;

    //[TestClass]
    //public class GuidTest : ValidatedBaseTypeTest<MyGuid, Guid>
    //{
    //    protected override Arbitrary<Guid> Arbitrary => Arb.Default.Guid().Filter(guid => guid != Guid.Empty);

    //    protected override MyGuid New(Guid value) => new(value);

    //    [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
    //    public void NoEmpty() => new MyGuid(Guid.Empty);
    //}
}
