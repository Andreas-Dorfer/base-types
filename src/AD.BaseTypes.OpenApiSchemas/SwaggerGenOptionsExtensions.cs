using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AD.BaseTypes.OpenApiSchemas
{
    public static class SwaggerGenOptionsExtensions
    {
        public static SwaggerGenOptions UseBaseTypeSchemas(this SwaggerGenOptions options)
        {
            options.SchemaFilter<BaseTypeSchemaFilter>();
            return options;
        }
    }
}
