namespace AD.BaseTypes;

/// <summary>
/// Common interface for all generated base types.
/// </summary>
/// <typeparam name="TWrapped">The wrapped value's type.</typeparam>
public interface IBaseType<out TWrapped> where TWrapped : notnull
{
    /// <summary>
    /// The wrapped Value.
    /// </summary>
    TWrapped Value { get; }
}

/// <summary>
/// Common interface for all generated base types.
/// </summary>
/// <typeparam name="TBaseType">The base types' type.</typeparam>
/// <typeparam name="TWrapped">The wrapped value's type.</typeparam>
public interface IBaseType<TBaseType, TWrapped> : IBaseType<TWrapped> where TBaseType : IBaseType<TBaseType, TWrapped> where TWrapped : notnull
{
    /// <summary>
    /// Creates the base type.
    /// </summary>
    /// <param name="value">The wrapped value.</param>
    /// <returns>The created base type.</returns>
    /// <exception cref="ArgumentException">The parameter <paramref name="value"/> is invalid.</exception>
    static abstract TBaseType From(TWrapped value);
}
