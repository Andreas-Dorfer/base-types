using BenchmarkDotNet.Attributes;

namespace AD.BaseTypes.Benchmarks;

[NonEmptyString] public sealed partial record StaticNonEmptyString;

[AttributeUsage(AttributeTargets.Class)]
public sealed class InstanceNonEmptyStringAttribute : Attribute, IBaseTypeValidation<string>
{
    public void Validate(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == string.Empty) throw new ArgumentOutOfRangeException(nameof(value), value, "Parameter must not be empty.");
    }
}

[InstanceNonEmptyString] public sealed partial record InstanceNonEmptyString;

[MemoryDiagnoser]
public class NonEmptyStringBenchmark
{
    readonly string value = "teststring";

#pragma warning disable CA1806 // Do not ignore method results
    [Benchmark]
    public void WithInstanceMethod() => new InstanceNonEmptyString(value);

    [Benchmark]
    public void WithStaticMethod() => new StaticNonEmptyString(value);
#pragma warning restore CA1806 // Do not ignore method results
}
