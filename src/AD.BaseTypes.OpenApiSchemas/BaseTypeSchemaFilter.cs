using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace AD.BaseTypes.OpenApiSchemas
{
    /// <summary>
    /// Schema filter for base types.
    /// </summary>
    public class BaseTypeSchemaFilter : ISchemaFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var iBaseType = TryGetBaseType(context.Type);
            if (iBaseType is null) return;
            var wrappedType = iBaseType.GenericTypeArguments[0];

            if (!context.SchemaRepository.TryLookupByType(wrappedType, out var wrappedSchema))
            {
                wrappedSchema = context.SchemaGenerator.GenerateSchema(wrappedType, context.SchemaRepository);
            }
            schema.Type = wrappedSchema.Type;
            foreach (var (key, prop) in wrappedSchema.Properties)
            {
                schema.Properties.Add(key, prop);
            }
        }

        static Type? TryGetBaseType(Type type)
        {
            try
            {
                return type.GetInterface(typeof(IBaseType<>).FullName!);
            }
            catch (AmbiguousMatchException)
            {
                return null;
            }
        }
    }
}
