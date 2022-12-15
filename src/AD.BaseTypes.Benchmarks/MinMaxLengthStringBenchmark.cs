using BenchmarkDotNet.Attributes;

namespace AD.BaseTypes.Benchmarks;

[MinMaxLengthString(MinLength, MaxLength)]
public sealed partial record StaticMinMaxLengthString
{
    public const int MinLength = 5, MaxLength = 15;
}

[AttributeUsage(AttributeTargets.Class)]
public sealed class InstanceMinMaxLengthStringAttribute : Attribute, IBaseTypeValidation<string>
{
    readonly int minLength, maxLength;

    public InstanceMinMaxLengthStringAttribute(int minLength, int maxLength)
    {
        this.minLength = minLength;
        this.maxLength = maxLength;
    }

    public void Validate(string value)
    {
        StringValidation.MinLength(minLength, value);
        StringValidation.MaxLength(maxLength, value);
    }
}

[InstanceMinMaxLengthString(StaticMinLengthString.MinLength, StaticMaxLengthString.MaxLength)] public sealed partial record InstanceMinMaxLengthString;

[MemoryDiagnoser]
public class MinMaxLengthStringBenchmark
{
    readonly string value = "teststring";

#pragma warning disable CA1806 // Do not ignore method results
    [Benchmark]
    public void WithInstanceMethod() => new InstanceMinMaxLengthString(value);

    [Benchmark]
    public void WithStaticMethod() => new StaticMinMaxLengthString(value);
#pragma warning restore CA1806 // Do not ignore method results
}
