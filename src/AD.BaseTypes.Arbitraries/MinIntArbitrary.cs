namespace AD.BaseTypes.Arbitraries;

/// <summary>
/// Arbitrary for int base types with a minimal value.
/// </summary>
/// <typeparam name="TBaseType">The base type.</typeparam>
public class MinIntArbitrary<TBaseType> : IntArbitrary<TBaseType> where TBaseType : IBaseType<TBaseType, int>
{
    /// <param name="min">The minimal value.</param>
    public MinIntArbitrary(int min)
    {
        Min = min;
    }

    /// <summary>
    /// The minimal value.
    /// </summary>
    protected int Min { get; }

    /// <summary>
    /// Filters too small values.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns>True, if the value is valid.</returns>
    protected override bool Filter(int value) => value >= Min;

    /// <inheritdoc/>
    public override Gen<TBaseType> Generator => Gen.Sized(i =>
    {
        var maxAdd = Min > 0 ? int.MaxValue - Min : int.MaxValue;
        return Gen.Choose(Min, Min + Math.Min(i, maxAdd));
    }).Select(Creator);
}
