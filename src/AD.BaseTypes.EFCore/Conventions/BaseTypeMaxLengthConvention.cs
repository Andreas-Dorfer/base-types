using AD.BaseTypes.EFCore.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace AD.BaseTypes.EFCore.Conventions;

/// <summary>
/// Configures the maximum length of data that can be stored in all <see cref="T:IBaseType&lt;TBaseType,string&gt;"/> 
/// properties when a model is being finalized.
/// </summary>
/// <remarks>
///   Supported attributes are: 
///   <list type="bullet">
///     <item><description><see cref="MaxLengthStringAttribute"/></description></item>
///     <item><description><see cref="MinMaxLengthStringAttribute"/></description></item>
///   </list>
///   See <see href="https://aka.ms/efcore-docs-conventions">Model building conventions</see> for more information and examples.
/// </remarks>
public class BaseTypeMaxLengthConvention : IModelFinalizingConvention
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
            if (Attribute.GetCustomAttribute(baseTypeProperty.ClrType, typeof(MaxLengthStringAttribute)) is
                MaxLengthStringAttribute maxLengthStringAttribute)
            {
                baseTypeProperty.Builder.HasMaxLength(maxLengthStringAttribute.MaxLength);
                continue;
            }

            if (Attribute.GetCustomAttribute(baseTypeProperty.ClrType, typeof(MinMaxLengthStringAttribute)) is
                MinMaxLengthStringAttribute minMaxLengthStringAttribute)
            {
                baseTypeProperty.Builder.HasMaxLength(minMaxLengthStringAttribute.MaxLength);
            }
        }
    }
}