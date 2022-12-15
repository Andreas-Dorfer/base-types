using AD.BaseTypes.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace AD.BaseTypes.EFCore;

/// <summary>
/// Apply the value converter <see cref="BaseTypeValueConverter{TBaseType, TWrapped}"/> as a convention 
/// to all <see cref="IBaseType{TBaseType,TWrapped}"/> properties when a model is being finalized.
/// </summary>
/// <remarks>
/// See <see href="https://aka.ms/efcore-docs-conventions">Model building conventions</see> for more information and examples.
/// </remarks>
public class BaseTypeConversionConvention : IModelFinalizingConvention
{
    static readonly Type BaseType = typeof(IBaseType<,>);

    /// <summary>
    /// Called when a model is being finalized.
    /// </summary>
    /// <param name="modelBuilder">The builder for the model.</param>
    /// <param name="context">Additional information associated with convention execution.</param>
    public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
    {
        var baseTypesProperties = modelBuilder.Metadata
            .GetEntityTypes()
            .SelectMany(x => x.GetDeclaredProperties())
            .Where(x => x.ClrType.ImplementsIBaseType());

        foreach (var baseTypeProperty in baseTypesProperties)
        {
            var wrappedType = baseTypeProperty.ClrType
                .GetInterfaces()
                .First(x => x.IsGenericType && x.GetGenericTypeDefinition() == BaseType)
                .GetGenericArguments()[1];

            var converterType = typeof(BaseTypeValueConverter<,>).MakeGenericType(new Type[] { baseTypeProperty.ClrType, wrappedType });

            baseTypeProperty.Builder.HasConverter(converterType);
        }
    }
}
