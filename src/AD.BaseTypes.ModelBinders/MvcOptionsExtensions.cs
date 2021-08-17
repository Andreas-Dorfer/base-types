using Microsoft.AspNetCore.Mvc;

namespace AD.BaseTypes.ModelBinders
{
    /// <summary>
    /// MVC options extensions.
    /// </summary>
    public static class MvcOptionsExtensions
    {
        /// <summary>
        /// Inserts the <see cref="BaseTypeModelBinderProvider"/>.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The options.</returns>
        public static MvcOptions UseBaseTypeModelBinders(this MvcOptions options)
        {
            options.ModelBinderProviders.Insert(0, new BaseTypeModelBinderProvider());
            return options;
        }
    }
}
