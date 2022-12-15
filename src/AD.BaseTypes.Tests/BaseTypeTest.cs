using System.ComponentModel;
using System.Text.Json;

namespace AD.BaseTypes.Tests;

public abstract class BaseTypeTest<TBaseType, TWrapped> where TBaseType : IBaseType<TBaseType, TWrapped>, IComparable<TBaseType> where TWrapped : IComparable<TWrapped>
{
    readonly TypeConverter converter = TypeDescriptor.GetConverter(typeof(TBaseType));
    readonly TypeConverter wrappedConverter = TypeDescriptor.GetConverter(typeof(TWrapped));

    protected abstract Arbitrary<TBaseType> Arbitrary { get; }
    protected virtual bool JsonFilter(TWrapped value) => true;

    [TestMethod]
    public void Create() => Prop.ForAll(Arbitrary, _ => true).VerboseCheckThrowOnFailure();

    [TestMethod]
    public void Equals() => Prop.ForAll(Arbitrary, a => Assert.AreEqual(a, TBaseType.From(a.Value))).QuickCheckThrowOnFailure();

    [TestMethod]
    public void Compare() => Prop.ForAll(Arbitrary, Arbitrary, (a, b) => Assert.AreEqual(a.Value.CompareTo(b.Value), a.CompareTo(b))).QuickCheckThrowOnFailure();

    [TestMethod]
    public void ConvertFrom() =>
        Prop.ForAll(Arbitrary, baseType => converter.CanConvertFrom(typeof(TWrapped)) && Equals(baseType, converter.ConvertFrom(baseType.Value))).QuickCheckThrowOnFailure();

    [TestMethod]
    public void ConvertTo() =>
        Prop.ForAll(Arbitrary, baseType => converter.CanConvertTo(typeof(TWrapped)) && Equals(baseType.Value, converter.ConvertTo(baseType, typeof(TWrapped)))).QuickCheckThrowOnFailure();

    [TestMethod]
    public void ConvertFromString() =>
        Prop.ForAll(Arbitrary, baseType =>
        {
            var @string = wrappedConverter.ConvertToString(baseType.Value);
            var value = (TWrapped)wrappedConverter.ConvertFromString(@string!)!;
            return converter.CanConvertFrom(typeof(string)) && Equals(TBaseType.From(value), converter.ConvertFromString(@string!));
        }).QuickCheckThrowOnFailure();

    [TestMethod]
    public void ConvertToString() =>
        Prop.ForAll(Arbitrary, baseType => converter.CanConvertTo(typeof(string)) && wrappedConverter.ConvertToString(baseType.Value) == converter.ConvertToString(baseType)).QuickCheckThrowOnFailure();

    [TestMethod]
    public void Json() =>
        Prop.ForAll(Arbitrary.Filter(_ => JsonFilter(_.Value)), baseType =>
        {
            var serializedValue = JsonSerializer.Serialize(baseType.Value);
            var serialized = JsonSerializer.Serialize(baseType);

            return serializedValue == serialized && Equals(baseType, JsonSerializer.Deserialize<TBaseType>(serialized));
        }).QuickCheckThrowOnFailure();
}
