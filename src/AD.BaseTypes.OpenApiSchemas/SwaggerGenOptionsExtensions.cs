using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AD.BaseTypes.OpenApiSchemas
{
    /// <summary>
    /// SwaggerGen options extensions.
    /// </summary>
    public static class SwaggerGenOptionsExtensions
    {
        /// <summary>
        /// Adds the <see cref="BaseTypeSchemaFilter"/>.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The options.</returns>
        public static SwaggerGenOptions UseBaseTypeSchemas(this SwaggerGenOptions options)
        {
            options.SchemaFilter<BaseTypeSchemaFilter>();
            return options;
        }
    }
}
