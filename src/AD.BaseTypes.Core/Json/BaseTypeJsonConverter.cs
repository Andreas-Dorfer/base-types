using System.Text.Json;
using System.Text.Json.Serialization;

namespace AD.BaseTypes.Json;

/// <summary>
/// Json converter for base types.
/// </summary>
/// <typeparam name="TBaseType">The base type.</typeparam>
/// <typeparam name="TWrapped">The wrapped type.</typeparam>
public sealed class BaseTypeJsonConverter<TBaseType, TWrapped> : JsonConverter<TBaseType> where TBaseType : IBaseType<TBaseType, TWrapped> where TWrapped : notnull
{
    static readonly Type WrappedType = typeof(TWrapped);

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, TBaseType baseType, JsonSerializerOptions options) =>
        GetConverter(options).Write(writer, baseType.Value, options);

    /// <inheritdoc/>
    public override TBaseType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = GetConverter(options).Read(ref reader, WrappedType, options);
        return value is null ? default : From(value);
    }


    /* ************************************************
     * see https://github.com/dotnet/runtime/pull/77488
     * ************************************************ */
#if NET8_0_OR_GREATER
    /// <inheritdoc/>
    public override void WriteAsPropertyName(Utf8JsonWriter writer, TBaseType baseType, JsonSerializerOptions options) =>
        GetConverter(options).WriteAsPropertyName(writer, baseType.Value, options);

    /// <inheritdoc/>
    public override TBaseType ReadAsPropertyName(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        From(GetConverter(options).ReadAsPropertyName(ref reader, WrappedType, options));
#warning remove else
#else
    static readonly DummyConverter PropertyConverter = new();

    sealed class DummyConverter : JsonConverter<TWrapped>
    {
        public override TWrapped? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => throw new NotImplementedException();
        public override void Write(Utf8JsonWriter writer, TWrapped value, JsonSerializerOptions options) => throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public override void WriteAsPropertyName(Utf8JsonWriter writer, TBaseType baseType, JsonSerializerOptions options) =>
        PropertyConverter.WriteAsPropertyName(writer, baseType.Value, options);

    /// <inheritdoc/>
    public override TBaseType ReadAsPropertyName(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        From(PropertyConverter.ReadAsPropertyName(ref reader, WrappedType, options));
#endif
    /* ************************************************ */


    static JsonConverter<TWrapped> GetConverter(JsonSerializerOptions options) =>
        options.GetConverter(WrappedType) as JsonConverter<TWrapped> ?? throw new NotSupportedException($"There is no converter for type '{WrappedType}'.");

    static TBaseType From(TWrapped value) =>
        BaseType<TBaseType, TWrapped>.TryFrom(value, out var baseType, out var errorMessage) ? baseType : throw new JsonException(errorMessage);
}
