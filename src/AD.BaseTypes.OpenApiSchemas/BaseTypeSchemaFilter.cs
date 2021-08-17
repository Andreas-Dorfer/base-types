using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Reflection;

namespace AD.BaseTypes.OpenApiSchemas
{
    public class BaseTypeSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var iBaseType = TryGetBaseType(context.Type);
            if (iBaseType is null) return;

            var wrappedSchema = schema.Properties["value"];
            if (wrappedSchema is not null)
            {
                schema.Properties.Remove("value");
                schema.Type = wrappedSchema.Type;
                foreach (var (key, prop) in wrappedSchema.Properties)
                {
                    schema.Properties.Add(key, prop);
                }
            }
        }

        static Type? TryGetBaseType(Type type)
        {
            try
            {
                return type.GetInterface(typeof(IBaseType<>).Name);
            }
            catch (AmbiguousMatchException)
            {
                return null;
            }
        }
    }
}
