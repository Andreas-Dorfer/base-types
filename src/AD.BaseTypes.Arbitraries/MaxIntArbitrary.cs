namespace AD.BaseTypes.Arbitraries;

/// <summary>
/// Arbitrary for int base types with a maximal value.
/// </summary>
/// <typeparam name="TBaseType"></typeparam>
/// <param name="max">The maximal value.</param>
public class MaxIntArbitrary<TBaseType>(int max) : IntArbitrary<TBaseType> where TBaseType : IBaseType<TBaseType, int>
{
    /// <summary>
    /// The maximal value.
    /// </summary>
    protected int Max { get; } = max;

    /// <summary>
    /// Filters too large values.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns>True, if the value is valid.</returns>
    protected override bool Filter(int value) => value <= Max;

    /// <inheritdoc/>
    public override Gen<TBaseType> Generator => Gen.Sized(i =>
    {
        var maxSub = Max < 0 ? int.MaxValue + Max + 1 : int.MaxValue;
        return Gen.Choose(Max - Math.Min(i, maxSub), Max);
    }).Select(Creator);
}
