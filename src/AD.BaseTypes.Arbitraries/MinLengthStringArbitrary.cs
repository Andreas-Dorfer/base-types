namespace AD.BaseTypes.Arbitraries;

/// <summary>
/// Arbitrary for string base types with a minimal range.
/// </summary>
/// <typeparam name="TBaseType"></typeparam>
public class MinLengthStringArbitrary<TBaseType> : StringArbitrary<TBaseType> where TBaseType : IBaseType<TBaseType, string>
{
    /// <param name="minLength">The minimal length.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="minLength"/> is negative.</exception>
    public MinLengthStringArbitrary(int minLength)
    {
        if (minLength < 0) throw new ArgumentOutOfRangeException(nameof(minLength), minLength, "Minimal length must be at least 0.");
        MinLength = minLength;
    }

    /// <summary>
    /// The minimal length.
    /// </summary>
    protected int MinLength { get; }

    /// <summary>
    /// Filters too short values.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns>True, if the value is valid.</returns>
    protected override bool Filter(string value) => value is not null && value.Length >= MinLength;

    /// <inheritdoc/>
    public override Gen<TBaseType> Generator =>
        Gen.Sized(i => StringGeneration.Generate(MinLength, MinLength + i, Creator));
}
