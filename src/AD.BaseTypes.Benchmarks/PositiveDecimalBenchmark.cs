using BenchmarkDotNet.Attributes;

namespace AD.BaseTypes.Benchmarks;

[PositiveDecimal] public sealed partial record StaticPositiveDecimal;

[AttributeUsage(AttributeTargets.Class)]
public sealed class InstancePositiveDecimalAttribute : Attribute, IBaseTypeValidation<decimal>
{
    public void Validate(decimal value)
    {
        if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), value, "Parameter must not be negative.");
    }
}

[InstancePositiveDecimal] public sealed partial record InstancePositiveDecimal;

[MemoryDiagnoser]
public class PositiveDecimalBenchmark
{
    readonly decimal value = 42;

#pragma warning disable CA1806 // Do not ignore method results
    [Benchmark]
    public void WithInstanceMethod() => new InstancePositiveDecimal(value);

    [Benchmark]
    public void WithStaticMethod() => new StaticPositiveDecimal(value);
#pragma warning restore CA1806 // Do not ignore method results
}
