namespace AD.BaseTypes;

/// <summary>
/// A validated wrapper around a (primitive) type.
/// </summary>
/// <typeparam name="TWrapped">The type to wrap.</typeparam>
public interface IBaseTypeValidation<TWrapped> : IBaseTypeDefinition<TWrapped> where TWrapped : notnull
{
    /// <summary>
    /// Validates the wrapped value.
    /// </summary>
    /// <param name="value">The value to be validated.</param>
    /// <exception cref="ArgumentException">The parameter <paramref name="value"/> is invalid.</exception>
    void Validate(TWrapped value);
}
