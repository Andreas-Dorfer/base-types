using AD.BaseTypes.EFCore.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AD.BaseTypes.EFCore.Extensions;

/// <summary>
/// Convention set builder extensions.
/// </summary>
public static class ConventionSetBuilderExtensions
{
    /// <summary>
    /// Apply base type conventions to all <see cref="IBaseType{TBaseType,TWrapped}"/> properties when a model is being finalized.
    /// </summary>
    /// <param name="conventionSetBuilder">Builder for configuring conventions.</param>
    /// <remarks>
    ///   Conventions applied are: 
    ///   <list type="bullet">
    ///     <item><description><see cref="BaseTypeConversionConvention"/></description></item>
    ///     <item><description><see cref="BaseTypeMaxLengthConvention"/></description></item>
    ///     <item><description><see cref="BaseTypeIsRequiredConvention"/></description></item>
    ///   </list>
    /// </remarks>
    /// <returns>The convention set builder</returns>
    public static ConventionSetBuilder AddBaseTypeConventions(this ConventionSetBuilder conventionSetBuilder) =>
        conventionSetBuilder
            .AddBaseTypeConversionConvention()
            .AddBaseTypeMaxLengthConvention()
            .AddBaseTypeIsRequiredConvention();

    /// <summary>
    /// Apply the value converter <see cref="BaseTypeValueConverter{TBaseType, TWrapped}"/> as a convention 
    /// to all <see cref="IBaseType{TBaseType,TWrapped}"/> properties when a model is being finalized.
    /// </summary>
    /// <param name="conventionSetBuilder">Builder for configuring conventions.</param>
    /// <returns>The convention set builder</returns>
    public static ConventionSetBuilder AddBaseTypeConversionConvention(this ConventionSetBuilder conventionSetBuilder)
    {
        conventionSetBuilder.Add(_ => new BaseTypeConversionConvention());
        return conventionSetBuilder;
    }

    /// <summary>
    /// Configures the maximum length of data that can be stored in all<see cref="T:IBaseType&lt;TBaseType,string&gt;"/>
    /// properties when a model is being finalized.
    /// </summary>
    /// <param name="conventionSetBuilder">Builder for configuring conventions.</param>
    /// <returns>The convention set builder</returns>
    public static ConventionSetBuilder AddBaseTypeMaxLengthConvention(this ConventionSetBuilder conventionSetBuilder)
    {
        conventionSetBuilder.Add(_ => new BaseTypeMaxLengthConvention());
        return conventionSetBuilder;
    }

    /// <summary>
    /// Configures the <see cref="IBaseType{TBaseType,TWrapped}"/> properties using the required keyword as 
    /// required when a model is being finalized.
    /// </summary>
    /// <param name="conventionSetBuilder">Builder for configuring conventions.</param>
    /// <returns>The convention set builder</returns>
    public static ConventionSetBuilder AddBaseTypeIsRequiredConvention(this ConventionSetBuilder conventionSetBuilder)
    {
        conventionSetBuilder.Add(_ => new BaseTypeIsRequiredConvention());
        return conventionSetBuilder;
    }
}