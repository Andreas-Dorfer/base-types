namespace AD.BaseTypes;

/// <summary>
/// A wrapper around a (primitve) type.
/// </summary>
/// <typeparam name="TWrapped">The type to wrap.</typeparam>
public interface IBaseTypeDefinition<TWrapped> where TWrapped : notnull
{ }
