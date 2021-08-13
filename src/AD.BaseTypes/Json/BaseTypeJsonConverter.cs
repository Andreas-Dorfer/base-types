using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AD.BaseTypes.Json
{
    /// <summary>
    /// Json converter for base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    /// <typeparam name="TWrapped">The wrapped type.</typeparam>
    public class BaseTypeJsonConverter<TBaseType, TWrapped> : JsonConverter<TBaseType> where TBaseType : IBaseType<TWrapped>
    {
        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, TBaseType baseType, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, baseType.Value, options);

        /// <inheritdoc/>
        public override TBaseType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = JsonSerializer.Deserialize<TWrapped>(ref reader, options);
            return value is null ? default : BaseType<TBaseType, TWrapped>.Create(value);
        }
    }
}
