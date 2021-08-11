using System;
using System.Text.Json.Serialization;

namespace AD.BaseTypes.Json
{
    public abstract class BaseTypeJsonConverter<TBaseType, TWrapped> : JsonConverter<TBaseType> where TBaseType : IValue<TWrapped>
    {
        public BaseTypeJsonConverter(Func<TWrapped, TBaseType> creator)
        {
            Creator = creator;
        }

        protected Func<TWrapped, TBaseType> Creator { get; }
    }
}
