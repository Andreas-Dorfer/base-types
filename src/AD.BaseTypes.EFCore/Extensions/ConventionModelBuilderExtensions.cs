using AD.BaseTypes.Extensions;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AD.BaseTypes.EFCore.Extensions;

internal static class ConventionModelBuilderExtensions
{
    /// <summary>
    /// Gets all non-navigation properties implementing <see cref="IBaseType{TBaseType,TWrapped}"/> declared on the entity type.
    /// </summary>
    /// <param name="modelBuilder">Convention model builder</param>
    /// <returns>Declared non-navigation properties implementing <see cref="IBaseType{TBaseType,TWrapped}"/>.</returns>
    public static IEnumerable<IConventionProperty> GetBaseTypeConventionProperties(this IConventionModelBuilder modelBuilder) =>
        modelBuilder.Metadata
            .GetEntityTypes()
            .SelectMany(x => x.GetDeclaredProperties())
            .Where(x => x.ClrType.ImplementsIBaseType());
}
