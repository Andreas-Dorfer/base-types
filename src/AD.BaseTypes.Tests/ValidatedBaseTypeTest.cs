﻿using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;

namespace AD.BaseTypes.Tests
{
    public abstract class ValidatedBaseTypeTest<TBaseType, TWrapped> where TBaseType : IBaseType<TWrapped>
    {
        protected abstract TBaseType New(TWrapped value);
        protected abstract Arbitrary<TWrapped> Arbitrary { get; }

        protected TypeConverter Converter { get; } = TypeDescriptor.GetConverter(typeof(TBaseType));
        protected TypeConverter WrappedConverter { get; } = TypeDescriptor.GetConverter(typeof(TWrapped));

        [TestMethod]
        public void Create() =>
            Prop.ForAll(Arbitrary, value => Equals(value, New(value).Value)).QuickCheckThrowOnFailure();

        [TestMethod]
        public void ConvertFrom() =>
            Prop.ForAll(Arbitrary, value => Converter.CanConvertFrom(typeof(TWrapped)) && Equals(value, ((TBaseType)Converter.ConvertFrom(value)).Value)).QuickCheckThrowOnFailure();

        [TestMethod]
        public void ConvertTo() =>
            Prop.ForAll(Arbitrary, value => Converter.CanConvertTo(typeof(TWrapped)) && Equals(value, Converter.ConvertTo(New(value), typeof(TWrapped)))).QuickCheckThrowOnFailure();

        [TestMethod]
        public void ConvertFromString() =>
            Prop.ForAll(Arbitrary, value =>
            {
                var @string = WrappedConverter.ConvertToString(value);
                return Converter.CanConvertFrom(typeof(string)) && Equals(WrappedConverter.ConvertFromString(@string), ((TBaseType)Converter.ConvertFromString(@string)).Value);
            }).QuickCheckThrowOnFailure();

        [TestMethod]
        public void ConvertToString() =>
            Prop.ForAll(Arbitrary, value => Converter.CanConvertTo(typeof(string)) && WrappedConverter.ConvertToString(value) == Converter.ConvertToString(New(value))).QuickCheckThrowOnFailure();
    }
}
