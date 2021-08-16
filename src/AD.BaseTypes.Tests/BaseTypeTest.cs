using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;

namespace AD.BaseTypes.Tests
{
    public abstract class BaseTypeTest<TBaseType, TWrapped> where TBaseType : IBaseType<TWrapped>
    {
        protected TypeConverter Converter => TypeDescriptor.GetConverter(typeof(TBaseType));
        protected TypeConverter WrappedConverter => TypeDescriptor.GetConverter(typeof(TWrapped));

        protected abstract TBaseType New(TWrapped value);

        [TestMethod]
        public void Create() =>
            Prop.ForAll<TWrapped>(value => Equals(value, New(value).Value)).QuickCheckThrowOnFailure();

        [TestMethod]
        public void ConvertFrom() =>
            Prop.ForAll<TWrapped>(value => Equals(value, ((TBaseType)Converter.ConvertFrom(value)).Value)).QuickCheckThrowOnFailure();

        [TestMethod]
        public void ConvertTo() =>
            Prop.ForAll<TWrapped>(value => Equals(value, Converter.ConvertTo(New(value), typeof(TWrapped)))).QuickCheckThrowOnFailure();

        [TestMethod]
        public void ConvertFromString() =>
            Prop.ForAll<TWrapped>(value =>
            {
                var @string = WrappedConverter.ConvertToString(value);
                return Equals(WrappedConverter.ConvertFromString(@string), ((TBaseType)Converter.ConvertFromString(@string)).Value);
            }).QuickCheckThrowOnFailure();

        [TestMethod]
        public void ConvertToString() =>
            Prop.ForAll<TWrapped>(value => WrappedConverter.ConvertToString(value) == Converter.ConvertToString(New(value))).QuickCheckThrowOnFailure();
    }
}
