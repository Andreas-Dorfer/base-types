namespace AD.BaseTypes.Arbitraries;

/// <summary>
/// Arbitrary for positive deicmal base types.
/// </summary>
/// <typeparam name="TBaseType"></typeparam>
public class PositiveDecimalArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, decimal> where TBaseType : IBaseType<TBaseType, decimal>
{
    /// <summary>
    /// Filters negative decimals.
    /// </summary>
    /// <param name="value">The decimal to check.</param>
    /// <returns>True, if the decimal is positive.</returns>
    protected override bool Filter(decimal value) => value >= 0;
}
