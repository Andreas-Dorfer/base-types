using System;
using System.ComponentModel;
using System.Globalization;

namespace AD.BaseTypes.Core
{
    /// <inheritdoc/>
    public class BaseTypeConverter<TBaseType, TWrapped> : TypeConverter where TBaseType : IBaseType<TWrapped>
    {
        readonly TypeConverter wrappedConverter = TypeDescriptor.GetConverter(typeof(TWrapped));

        /// <inheritdoc/>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) =>
            wrappedConverter.CanConvertFrom(context, sourceType);

        /// <inheritdoc/>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) =>
            wrappedConverter.CanConvertTo(context, destinationType);

        /// <inheritdoc/>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) =>
            BaseType<TBaseType, TWrapped>.Create((TWrapped)wrappedConverter.ConvertFrom(context, culture, value));

        /// <inheritdoc/>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) =>
            wrappedConverter.ConvertTo(context, culture, ((IBaseType<TWrapped>)value).Value, destinationType);
    }
}
