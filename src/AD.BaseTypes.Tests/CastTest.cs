namespace AD.BaseTypes.Tests;

[NonNullString] public partial record DefaultString;
[NonNullString, BaseType(Cast.Explicit)] public partial record ExplicitString;
[NonNullString, BaseType(Cast.Implicit)] public partial record ImplicitString;
[NonNullString, BaseType(Cast.None)] public partial record NoneString;

[TestClass]
public class CastTest
{
    [Property]
    public void Default_is_explicit(NonEmptyString str) =>
        Assert.AreEqual(str.Item, (string)BaseType<DefaultString, string>.Create(str.Item));

    [Property]
    public void Explicit(NonEmptyString str) =>
        Assert.AreEqual(str.Item, (string)BaseType<ExplicitString, string>.Create(str.Item));

    [Property]
    public void Implicit(NonEmptyString str) =>
        Assert.AreEqual(str.Item, BaseType<ImplicitString, string>.Create(str.Item));

    [Property]
    public void None(NonEmptyString str) =>
        Assert.AreNotEqual(str.Item, BaseType<NoneString, string>.Create(str.Item));
}
