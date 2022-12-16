namespace AD.BaseTypes.Tests;

[String] public partial record DefaultString;
[String, BaseType(Cast.Explicit)] public partial record ExplicitString;
[String, BaseType(Cast.Implicit)] public partial record ImplicitString;
[String, BaseType(Cast.None)] public partial record NoneString;

[TestClass]
public class CastTest
{
    [Property]
    public void Default_is_explicit(NonEmptyString str) =>
        Assert.AreEqual(str.Item, (string)DefaultString.From(str.Item));

    [Property]
    public void Explicit(NonEmptyString str) =>
        Assert.AreEqual(str.Item, (string)ExplicitString.From(str.Item));

    [Property]
    public void Implicit(NonEmptyString str) =>
        Assert.AreEqual(str.Item, ImplicitString.From(str.Item));

    [Property]
    public void None(NonEmptyString str) =>
        Assert.AreNotEqual<object>(str.Item, NoneString.From(str.Item));
}


[Int] public readonly partial record struct DefaultIntStruct;
[Int, BaseType(Cast.Explicit)] public readonly partial record struct ExplicitIntStruct;
[Int, BaseType(Cast.Implicit)] public readonly partial record struct ImplicitIntStruct;
[Int, BaseType(Cast.None)] public readonly partial record struct NoneIntStruct;

[TestClass]
public class CastStructTest
{
    [Property]
    public void Default_is_explicit(int x) =>
        Assert.AreEqual(x, (int)DefaultIntStruct.From(x));

    [Property]
    public void Explicit(int x) =>
        Assert.AreEqual(x, (int)ExplicitIntStruct.From(x));

    [Property]
    public void Implicit(int x) =>
        Assert.AreEqual(x, ImplicitIntStruct.From(x));

    [Property]
    public void None(int x) =>
        Assert.AreNotEqual<object>(x, NoneIntStruct.From(x));
}
