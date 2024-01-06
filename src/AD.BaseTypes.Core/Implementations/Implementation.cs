using System.Diagnostics.CodeAnalysis;

namespace AD.BaseTypes.Implementations;

/// <summary>
/// Shared implementations for base types.
/// </summary>
public static class Implementation
{
    /// <inheritdoc cref="IParsable{TSelf}.Parse(string, IFormatProvider?)"/>
    /// <inheritdoc cref="IParsable{TSelf}" path="/typeparam[@name='TSelf']"/>
    public static TSelf Parse<TSelf>(string s, IFormatProvider? provider) where TSelf : IParsable<TSelf> =>
        TSelf.Parse(s, provider);

    /// <inheritdoc cref="IParsable{TSelf}.TryParse(string?, IFormatProvider?, out TSelf)"/>
    /// <inheritdoc cref="IParsable{TSelf}" path="/typeparam[@name='TSelf']"/>
    public static bool TryParse<TSelf>([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out TSelf result) where TSelf : IParsable<TSelf> =>
        TSelf.TryParse(s, provider, out result);
}
