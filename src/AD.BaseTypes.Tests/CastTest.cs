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


[Int] public readonly partial record struct DefaultIntStruct;
[Int, BaseType(Cast.Explicit)] public readonly partial record struct ExplicitIntStruct;
[Int, BaseType(Cast.Implicit)] public readonly partial record struct ImplicitIntStruct;
[Int, BaseType(Cast.None)] public readonly partial record struct NoneIntStruct;

[TestClass]
public class CastStructTest
{
    [Property]
    public void Default_is_explicit(int x) =>
        Assert.AreEqual(x, (int)BaseType<DefaultIntStruct, int>.Create(x));

    [Property]
    public void Explicit(int x) =>
        Assert.AreEqual(x, (int)BaseType<ExplicitIntStruct, int>.Create(x));

    [Property]
    public void Implicit(int x) =>
        Assert.AreEqual(x, BaseType<ImplicitIntStruct, int>.Create(x));

    [Property]
    public void None(int x) =>
        Assert.AreNotEqual(x, BaseType<NoneIntStruct, int>.Create(x));
}
