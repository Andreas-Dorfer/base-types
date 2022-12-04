using AD.BaseTypes.EFCore.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Runtime.CompilerServices;

namespace AD.BaseTypes.EFCore.Conventions;

/// <summary>
/// Configures the <see cref="IBaseType{TBaseType,TWrapped}"/> properties using the required keyword as 
/// required when a model is being finalized.
/// </summary>
/// <remarks>
/// See <see href="https://aka.ms/efcore-docs-conventions">Model building conventions</see> for more information and examples.
/// </remarks>
public class BaseTypeIsRequiredConvention : IModelFinalizingConvention
{
    /// <summary>
    /// Called when a model is being finalized.
    /// </summary>
    /// <param name="modelBuilder">The builder for the model.</param>
    /// <param name="context">Additional information associated with convention execution.</param>
    public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder,
        IConventionContext<IConventionModelBuilder> context)
    {
        foreach (var baseTypeProperty in modelBuilder.GetBaseTypeConventionProperties())
        {
            if (!baseTypeProperty.Builder.Metadata.IsNullable)
            {
                baseTypeProperty.Builder.IsRequired(true);
            }
        }
    }
}