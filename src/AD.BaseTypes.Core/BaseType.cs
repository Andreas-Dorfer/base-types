using System.Diagnostics.CodeAnalysis;

namespace AD.BaseTypes;

/// <summary>
/// Base type.
/// </summary>
/// <typeparam name="TBaseType">The base type.</typeparam>
/// <typeparam name="TWrapped">The wrapped type.</typeparam>
public static class BaseType<TBaseType, TWrapped> where TBaseType : IBaseType<TBaseType, TWrapped>
{
    /// <summary>
    /// Creates the base type.
    /// </summary>
    /// <param name="value">The wrapped value.</param>
    /// <returns>The created base type.</returns>
    /// <exception cref="ArgumentException">The parameter <paramref name="value"/> is invalid.</exception>
    public static TBaseType Create(TWrapped value) => TBaseType.Create(value);

    /// <summary>
    /// Tries to create a base type.
    /// </summary>
    /// <param name="value">The wrapped value.</param>
    /// <param name="baseType">The created base type.</param>
    /// <param name="errorMessage">The error message.</param>
    /// <returns>True, if the base type is created.</returns>
    public static bool TryCreate(TWrapped value, [MaybeNullWhen(false)] out TBaseType baseType, [MaybeNullWhen(true)] out string errorMessage)
    {
        try
        {
            baseType = Create(value);
            errorMessage = default;
            return true;
        }
        catch (ArgumentException ex)
        {
            baseType = default;
            errorMessage = ex.Message;
            return false;
        }
    }
}
