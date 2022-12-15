namespace AD.BaseTypes.Benchmarks;

[MaxLengthString(MaxLength)]
public sealed partial record StaticMaxLengthString
{
    public const int MaxLength = 10;
}

[AttributeUsage(AttributeTargets.Class)]
public sealed class InstanceMaxLengthStringAttribute : Attribute, IBaseTypeValidation<string>
{
    readonly int maxLength;

    public InstanceMaxLengthStringAttribute(int maxLength)
    {
        this.maxLength = maxLength;
    }

    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is too long.</exception>
    public void Validate(string value) => StringValidation.MaxLength(maxLength, value);
}

[InstanceMaxLengthString(StaticMaxLengthString.MaxLength)] public sealed partial record InstanceMaxLengthString;

[MemoryDiagnoser]
public class MaxLengthStringBenchmark
{
    readonly string value = "teststring";

#pragma warning disable CA1806 // Do not ignore method results
    [Benchmark]
    public void WithInstanceMethod() => new InstanceMaxLengthString(value);

    [Benchmark]
    public void WithStaticMethod() => new StaticMaxLengthString(value);
#pragma warning restore CA1806 // Do not ignore method results
}
