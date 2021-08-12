using System;
using System.Text.Json;

namespace AD.BaseTypes.Json
{
    public class DateTimeJsonConverter<TBaseType> : BaseTypeJsonConverter<TBaseType, DateTime> where TBaseType : class, IBaseType<DateTime>
    {
        public DateTimeJsonConverter(Func<DateTime, TBaseType> creator) : base(creator)
        { }

        public override void Write(Utf8JsonWriter writer, TBaseType value, JsonSerializerOptions options) =>
            writer.WriteStringValue(value.Value);

        public override TBaseType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            reader.TryGetDateTime(out var value) ? Creator(value) : null;
    }
}
