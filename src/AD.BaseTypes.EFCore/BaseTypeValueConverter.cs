using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AD.BaseTypes.EFCore;

/// <summary>
/// Defines conversions from an <see cref="IBaseType{TBaseType,TWrapped}" /> to the wrapped value's type, in the store.
/// </summary>
/// <remarks>
/// See <see href="https://aka.ms/efcore-docs-value-converters">EF Core value converters</see> for more information and examples.
/// </remarks>
public class BaseTypeValueConverter<TBaseType, TWrapped> : ValueConverter<TBaseType, TWrapped>
    where TBaseType : IBaseType<TBaseType, TWrapped>
    where TWrapped : notnull
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseTypeValueConverter{TBaseType,TWrapped}" /> class.
    /// </summary>
    public BaseTypeValueConverter()
        : base(
              v => v.Value,
              v => BaseType<TBaseType, TWrapped>.From(v))
    { }
}