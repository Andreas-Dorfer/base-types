namespace AD.BaseTypes.Arbitraries;

/// <summary>
/// Example based arbitrary.
/// </summary>
/// <typeparam name="TBaseType">The base type.</typeparam>
/// <typeparam name="TWrapped">The wrapped type.</typeparam>
/// <remarks>
/// Creates the arbitrary.
/// </remarks>
/// <param name="examples">The examples to use.</param>
/// <exception cref="ArgumentNullException">The parameter <paramref name="examples"/> is null.</exception>
public class ExampleArbitrary<TBaseType, TWrapped>(params TWrapped[] examples) : Arbitrary<TBaseType> where TBaseType : IBaseType<TBaseType, TWrapped> where TWrapped : notnull
{
    readonly TWrapped[] examples = examples ?? throw new ArgumentNullException(nameof(examples));

    /// <inheritdoc/>
    public override Gen<TBaseType> Generator => Gen.Elements(examples).Select(TBaseType.From);
}
