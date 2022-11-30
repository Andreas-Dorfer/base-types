using BenchmarkDotNet.Attributes;

namespace AD.BaseTypes.Benchmark;

[MemoryDiagnoser]
public class MaxLengthBenchmark
{
    readonly int maxLength = new Random().Next();
    readonly string value = "teststring";

    [Benchmark]
    public void WithAttribute() => new MaxLengthStringAttribute(maxLength).Validate(value);

    [Benchmark]
    public void WithStaticFunction() => StringValidation.MaxLength(maxLength, value);
}
