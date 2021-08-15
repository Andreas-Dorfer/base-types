using System;
using System.ComponentModel;
using System.Globalization;

namespace AD.BaseTypes.Core
{
    public class BaseTypeConverter<TBaseType, TWrapped> : TypeConverter where TBaseType : IBaseType<TWrapped>
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) =>
            sourceType == typeof(TWrapped);

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) =>
            destinationType == typeof(TWrapped);

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) =>
            BaseType<TBaseType, TWrapped>.Create((TWrapped)value);

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) =>
            ((IBaseType<TWrapped>)value).Value!;
    }
}
