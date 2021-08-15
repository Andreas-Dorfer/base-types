using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace AD.BaseTypes.ModelBinders
{
    public class BaseTypeModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            var baseType = context.Metadata.ModelType;
            var iBaseType = baseType.GetInterface(typeof(IBaseType<>).Name);
            if (iBaseType is null) return null!;

            var wrapped = iBaseType.GenericTypeArguments[0];
            return new BinderTypeModelBinder(typeof(BaseTypeModelBinder<,>).MakeGenericType(baseType, wrapped));
        }
    }
}
