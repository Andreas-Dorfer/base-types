using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace AD.BaseTypes.ModelBinders
{
    public class BaseTypeModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            var type = context.Metadata.ModelType;
            var baseTypeInterface = type.GetInterface(typeof(IBaseType<>).Name);
            var wrappedType = baseTypeInterface?.GenericTypeArguments[0];

            return new BinderTypeModelBinder(typeof(BaseTypeModelBinder<,>).MakeGenericType(type, wrappedType!));
        }
    }
}
