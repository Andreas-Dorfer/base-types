namespace AD.BaseTypes;

/// <summary>
/// A validated wrapper around a (primitive) type.
/// </summary>
/// <typeparam name="TWrapped">The type to wrap.</typeparam>
/// <remarks>Must define a static Validate method.</remarks>
public interface IStaticBaseTypeValidation<TWrapped> : IBaseTypeDefinition<TWrapped> where TWrapped : notnull
{ }