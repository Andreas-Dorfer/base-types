using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AD.BaseTypes.Tests
{
    [String] public partial record DefaultString;
    [String, BaseType(Cast.Explicit)] public partial record ExplicitString;
    [String, BaseType(Cast.Implicit)] public partial record ImplicitString;
    [String, BaseType(Cast.None)] public partial record NoneString;

    [TestClass]
    public class CastTest
    {
        [TestMethod]
        public void Default_is_explicit() =>
            Prop.ForAll<NonEmptyString>(str => Assert.AreEqual(str.Item, (string)BaseType<DefaultString, string>.Create(str.Item))).QuickCheckThrowOnFailure();

        [TestMethod]
        public void Explicit() =>
            Prop.ForAll<NonEmptyString>(str => Assert.AreEqual(str.Item, (string)BaseType<ExplicitString, string>.Create(str.Item))).QuickCheckThrowOnFailure();

        [TestMethod]
        public void Implicit() =>
            Prop.ForAll<NonEmptyString>(str => Assert.AreEqual(str.Item, BaseType<ImplicitString, string>.Create(str.Item))).QuickCheckThrowOnFailure();

        [TestMethod]
        public void None() =>
            Prop.ForAll<NonEmptyString>(str => Assert.AreNotEqual(str.Item, BaseType<NoneString, string>.Create(str.Item))).QuickCheckThrowOnFailure();
    }
}
