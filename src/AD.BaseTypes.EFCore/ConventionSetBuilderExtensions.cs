using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AD.BaseTypes.EFCore;

/// <summary>
/// Convention set builder extensions.
/// </summary>
public static class ConventionSetBuilderExtensions
{
    /// <summary>
    /// Apply the value converter <see cref="BaseTypeValueConverter{TBaseType, TWrapped}"/> as a convention 
    /// to all <see cref="IBaseType{TBaseType,TWrapped}"/> properties when a model is being finalized.
    /// </summary>
    /// <param name="conventionSetBuilder">Builder for configuring conventions.</param>
    /// <returns>The <see cref="ConventionSetBuilder"/></returns>
    public static ConventionSetBuilder AddBaseTypeConversionConvention(this ConventionSetBuilder conventionSetBuilder)
    {
        conventionSetBuilder.Add(_ => new BaseTypeConversionConvention());
        return conventionSetBuilder;
    }
}
