namespace AD.BaseTypes.Benchmarks;

[NonEmptyGuid] public sealed partial record StaticNonEmptyGuid;

[AttributeUsage(AttributeTargets.Class)]
public sealed class InstanceNonEmptyGuidAttribute : Attribute, IBaseTypeValidation<Guid>
{
    public void Validate(Guid value)
    {
        if (value == Guid.Empty) throw new ArgumentOutOfRangeException(nameof(value), value, "Parameter must not be empty.");
    }
}

[InstanceNonEmptyGuid] public sealed partial record InstanceNonEmptyGuid;

[MemoryDiagnoser]
public class NonEmptyGuidBenchmark
{
    readonly Guid value = Guid.NewGuid();

#pragma warning disable CA1806 // Do not ignore method results
    [Benchmark]
    public void WithInstanceMethod() => new InstanceNonEmptyGuid(value);

    [Benchmark]
    public void WithStaticMethod() => new StaticNonEmptyGuid(value);
#pragma warning restore CA1806 // Do not ignore method results
}
