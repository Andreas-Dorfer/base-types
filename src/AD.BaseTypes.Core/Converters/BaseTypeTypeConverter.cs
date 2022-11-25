using System.ComponentModel;
using System.Globalization;

namespace AD.BaseTypes.Converters;

/// <inheritdoc/>
public class BaseTypeTypeConverter<TBaseType, TWrapped> : TypeConverter where TBaseType : IBaseType<TBaseType, TWrapped>
{
    readonly TypeConverter wrappedConverter = TypeDescriptor.GetConverter(typeof(TWrapped));

    /// <inheritdoc/>
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) =>
        sourceType == typeof(TWrapped) || wrappedConverter.CanConvertFrom(context, sourceType);

    /// <inheritdoc/>
    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType) =>
        destinationType == typeof(TWrapped) || wrappedConverter.CanConvertTo(context, destinationType);

    /// <inheritdoc/>
    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        if (value is not TWrapped wrapped)
        {
            wrapped = (TWrapped)wrappedConverter.ConvertFrom(context, culture, value)!;
        }
        return TBaseType.Create(wrapped);
    }

    /// <inheritdoc/>
    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (value is not IBaseType<TBaseType, TWrapped> baseType) return default!;

        var wrapped = baseType.Value;
        return destinationType == typeof(TWrapped) ? wrapped! : wrappedConverter.ConvertTo(context, culture, wrapped, destinationType);
    }
}
