namespace AD.BaseTypes.Arbitraries;

/// <summary>
/// Arbitrary for non-null string base types.
/// </summary>
/// <typeparam name="TBaseType">The base type.</typeparam>
public class StringArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, string> where TBaseType : IBaseType<string>
{
    /// <inheritdoc/>
    protected override Arbitrary<string> WrappedArb() => Arb.Default.NonNull<string>().Convert(str => str.Item, str => NonNull<string>.NewNonNull(str));

    /// <summary>
    /// Filters null.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns>True, if the string is not null.</returns>
    protected override bool Filter(string value) => value is not null;
}
