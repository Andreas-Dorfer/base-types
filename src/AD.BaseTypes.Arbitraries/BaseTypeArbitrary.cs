namespace AD.BaseTypes.Arbitraries;

/// <summary>
/// Arbitrary for base types.
/// </summary>
/// <typeparam name="TBaseType">The base type.</typeparam>
/// <typeparam name="TWrapped">The wrapped type.</typeparam>
public class BaseTypeArbitrary<TBaseType, TWrapped> : Arbitrary<TBaseType> where TBaseType : IBaseType<TBaseType, TWrapped>
{
    readonly Arbitrary<TWrapped> arb;

    /// <summary>
    /// Creates the arbitrary.
    /// </summary>
    public BaseTypeArbitrary()
    {
        arb = WrappedArb().Filter(Filter);
    }

    /// <summary>
    /// The arbitrary for the wrapped type.
    /// </summary>
    /// <returns>The arbitrary for the wrapped type.</returns>
    protected virtual Arbitrary<TWrapped> WrappedArb() => Arb.From<TWrapped>();

    /// <summary>
    /// The base type's creator.
    /// </summary>
    /// <param name="value">The wrapped value.</param>
    /// <returns>The base type.</returns>
    /// <exception cref="ArgumentException">The parameter <paramref name="value"/> is invalid.</exception>
    protected TBaseType Creator(TWrapped value) => TBaseType.From(value);

    /// <summary>
    /// Filters invalid wrapped values.
    /// </summary>
    /// <param name="value">The wrapped value to check.</param>
    /// <returns>True, if the wrapped value is valid.</returns>
    protected virtual bool Filter(TWrapped value) => true;

    /// <summary>
    /// Generates the base type.
    /// </summary>
    public override Gen<TBaseType> Generator => arb.Generator.Select(Creator);

    /// <summary>
    /// Shrinks the base type.
    /// </summary>
    /// <param name="baseType"></param>
    /// <returns></returns>
    public override IEnumerable<TBaseType> Shrinker(TBaseType baseType) => arb.Shrinker(baseType.Value).Select(Creator);
}
