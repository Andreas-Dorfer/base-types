using BenchmarkDotNet.Attributes;

namespace AD.BaseTypes.Benchmarks;

[MinMaxInt(Min, Max)]
public sealed partial record StaticMinMaxInt
{
    public const int Min = 10, Max = 20;
}

[AttributeUsage(AttributeTargets.Class)]
public sealed class InstanceMinMaxIntAttribute : Attribute, IBaseTypeValidation<int>
{
    readonly int min, max;

    public InstanceMinMaxIntAttribute(int min, int max)
    {
        this.min = min;
        this.max = max;
    }

    public void Validate(int value)
    {
        IntValidation.Min(min, value);
        IntValidation.Max(max, value);
    }
}

[InstanceMinMaxInt(StaticMinMaxInt.Min, StaticMinMaxInt.Max)] public sealed partial record InstanceMinMaxInt;

[MemoryDiagnoser]
public class MinMaxIntBenchmark
{
    readonly int value = 15;

#pragma warning disable CA1806 // Do not ignore method results
    [Benchmark]
    public void WithInstanceMethod() => new InstanceMinMaxInt(value);

    [Benchmark]
    public void WithStaticMethod() => new StaticMinMaxInt(value);
#pragma warning restore CA1806 // Do not ignore method results
}
