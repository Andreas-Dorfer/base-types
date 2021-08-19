using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System.Text.Json;

namespace AD.BaseTypes.Tests
{
    public abstract class BaseTypeTest<TBaseType, TWrapped> where TBaseType : IBaseType<TWrapped>
    {
        readonly TypeConverter converter = TypeDescriptor.GetConverter(typeof(TBaseType));
        readonly TypeConverter wrappedConverter = TypeDescriptor.GetConverter(typeof(TWrapped));

        protected abstract Arbitrary<TBaseType> Arbitrary { get; }
        protected virtual bool JsonFilter(TWrapped value) => true;

        [TestMethod]
        public void Create() => Prop.ForAll(Arbitrary, _ => true).VerboseCheckThrowOnFailure();

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
                var value = (TWrapped)wrappedConverter.ConvertFromString(@string);
                return converter.CanConvertFrom(typeof(string)) && Equals(BaseType<TBaseType, TWrapped>.Create(value), converter.ConvertFromString(@string));
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
}
