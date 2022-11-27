using BenchmarkDotNet.Attributes;

namespace AD.BaseTypes.Benchmark;

[MemoryDiagnoser]
public class MaxLengthBenchmark
{
    private int maxLength = new Random().Next();
    private string value = "teststring";

    [Benchmark]
    public void WithAttribute() => new MaxLengthStringAttribute(maxLength).Validate(value);

    [Benchmark]
    public void WithStaticFunction() => StringValidation.MaxLength(maxLength, value);
}
