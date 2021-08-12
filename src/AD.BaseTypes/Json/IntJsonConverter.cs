using System;
using System.Text.Json;

namespace AD.BaseTypes.Json
{
    public class IntJsonConverter<TBaseType> : BaseTypeJsonConverter<TBaseType, int> where TBaseType : class, IBaseType<int>
    {
        public IntJsonConverter(Func<int, TBaseType> creator) : base(creator)
        { }

        public override void Write(Utf8JsonWriter writer, TBaseType value, JsonSerializerOptions options) =>
            writer.WriteNumberValue(value.Value);

        public override TBaseType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            reader.TryGetInt32(out var value) ? Creator(value) : null;
    }
}
