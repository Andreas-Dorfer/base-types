using BenchmarkDotNet.Attributes;

namespace AD.BaseTypes.Benchmarks;

[String] public sealed partial record StaticString;

[AttributeUsage(AttributeTargets.Class)]
public sealed class InstanceStringAttribute : Attribute, IBaseTypeValidation<string>
{
    public void Validate(string value) => ArgumentNullException.ThrowIfNull(value);
}

[InstanceString] public sealed partial record InstanceString;

[MemoryDiagnoser]
public class StringBenchmark
{
    readonly string value = "teststring";

#pragma warning disable CA1806 // Do not ignore method results
    [Benchmark]
    public void WithInstanceMethod() => new InstanceString(value);

    [Benchmark]
    public void WithStaticMethod() => new StaticString(value);
#pragma warning restore CA1806 // Do not ignore method results
}
