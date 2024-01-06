namespace AD.BaseTypes;

/// <summary>
/// Arguments to the source generator.
/// </summary>
/// <remarks>
/// Arguments to the source generator.
/// </remarks>
/// <param name="cast">The generated cast operator.</param>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
public sealed class BaseTypeAttribute(Cast cast) : Attribute
{
    /// <summary>
    /// The generated cast operator.
    /// </summary>
    public Cast Cast { get; } = cast;
}
