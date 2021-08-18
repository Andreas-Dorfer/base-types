using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System.Text.Json;

namespace AD.BaseTypes.Tests
{
    public abstract class BaseTypeTest<TBaseType, TWrapped> where TBaseType : IBaseType<TWrapped>
    {
        protected abstract Arbitrary<TBaseType> Arbitrary { get; }

        protected TypeConverter Converter { get; } = TypeDescriptor.GetConverter(typeof(TBaseType));
        protected TypeConverter WrappedConverter { get; } = TypeDescriptor.GetConverter(typeof(TWrapped));

        [TestMethod]
        public void Create() => Prop.ForAll(Arbitrary, _ => true).VerboseCheckThrowOnFailure();

        [TestMethod]
        public void ConvertFrom() =>
            Prop.ForAll(Arbitrary, baseType => Converter.CanConvertFrom(typeof(TWrapped)) && Equals(baseType, Converter.ConvertFrom(baseType.Value))).QuickCheckThrowOnFailure();

        [TestMethod]
        public void ConvertTo() =>
            Prop.ForAll(Arbitrary, baseType => Converter.CanConvertTo(typeof(TWrapped)) && Equals(baseType.Value, Converter.ConvertTo(baseType, typeof(TWrapped)))).QuickCheckThrowOnFailure();

        [TestMethod]
        public void ConvertFromString() =>
            Prop.ForAll(Arbitrary, baseType =>
            {
                var @string = WrappedConverter.ConvertToString(baseType.Value);
                var value = (TWrapped)WrappedConverter.ConvertFromString(@string);
                return Converter.CanConvertFrom(typeof(string)) && Equals(BaseType<TBaseType, TWrapped>.Create(value), Converter.ConvertFromString(@string));
            }).QuickCheckThrowOnFailure();

        [TestMethod]
        public void ConvertToString() =>
            Prop.ForAll(Arbitrary, baseType => Converter.CanConvertTo(typeof(string)) && WrappedConverter.ConvertToString(baseType.Value) == Converter.ConvertToString(baseType)).QuickCheckThrowOnFailure();

        [TestMethod]
        public void Json() =>
            Prop.ForAll(Arbitrary, baseType =>
            {
                var serializedValue = JsonSerializer.Serialize(baseType.Value);
                var serialized = JsonSerializer.Serialize(baseType);

                return serializedValue == serialized && Equals(baseType, JsonSerializer.Deserialize<TBaseType>(serialized));

            }).QuickCheckThrowOnFailure();
    }
}
