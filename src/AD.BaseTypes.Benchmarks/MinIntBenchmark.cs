namespace AD.BaseTypes.Benchmarks;

[MinInt(Min)]
public sealed partial record StaticMinInt
{
    public const int Min = 100;
}

[AttributeUsage(AttributeTargets.Class)]
public sealed class InstanceMinIntAttribute : Attribute, IBaseTypeValidation<int>
{
    readonly int min;

    public InstanceMinIntAttribute(int min)
    {
        this.min = min;
    }

    public void Validate(int value) => IntValidation.Min(min, value);
}

[InstanceMinInt(StaticMinInt.Min)] public sealed partial record InstanceMinInt;

[MemoryDiagnoser]
public class MinIntBenchmark
{
    readonly int value = StaticMinInt.Min * 2;

#pragma warning disable CA1806 // Do not ignore method results
    [Benchmark]
    public void WithInstanceMethod() => new InstanceMinInt(value);

    [Benchmark]
    public void WithStaticMethod() => new StaticMinInt(value);
#pragma warning restore CA1806 // Do not ignore method results
}
