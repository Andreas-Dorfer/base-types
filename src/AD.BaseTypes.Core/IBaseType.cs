namespace AD.BaseTypes;

/// <summary>
/// Common interface for all generated base types.
/// </summary>
/// <typeparam name="TWrapped">The wrapped value's type.</typeparam>
public interface IBaseType<TWrapped>
{
    /// <summary>
    /// The wrapped Value.
    /// </summary>
    TWrapped Value { get; }
}
