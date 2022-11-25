using System.Runtime.CompilerServices;

namespace AD.BaseTypes;

/// <summary>
/// A validated wrapper around a (primitive) type.
/// </summary>
/// <typeparam name="TWrapped">The type to wrap.</typeparam>
public interface IBaseTypeValidation<TWrapped> : IBaseTypeDefinition<TWrapped>
{
    /// <summary>
    /// Validates the wrapped value.
    /// </summary>
    /// <param name="value">The value to be validated.</param>
    /// <param name="paramName">The value's name.</param>
    /// <exception cref="ArgumentException">The parameter <paramref name="value"/> is invalid.</exception>
    void Validate(TWrapped value, [CallerArgumentExpression(nameof(value))] string? paramName = null);
}
