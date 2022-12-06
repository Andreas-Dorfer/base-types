using BenchmarkDotNet.Attributes;

namespace AD.BaseTypes.Benchmarks;

[MaxInt(Max)]
public partial record StaticMaxInt
{
    public const int Max = 100;
}

[AttributeUsage(AttributeTargets.Class)]
public class InstanceMaxIntAttribute : Attribute, IBaseTypeValidation<int>
{
    readonly int max;

    public InstanceMaxIntAttribute(int max)
    {
        this.max = max;
    }

    public void Validate(int value) => IntValidation.Max(max, value);
}

[InstanceMaxInt(StaticMaxInt.Max)] public partial record InstanceMaxInt;

[MemoryDiagnoser]
public class MaxIntBenchmark
{
    readonly int value = StaticMaxInt.Max / 2;

#pragma warning disable CA1806 // Do not ignore method results
    [Benchmark]
    public void WithInstanceMethod() => new InstanceMaxInt(value);

    [Benchmark]
    public void WithStaticMethod() => new StaticMaxInt(value);
#pragma warning restore CA1806 // Do not ignore method results
}
