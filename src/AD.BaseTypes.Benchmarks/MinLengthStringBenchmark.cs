namespace AD.BaseTypes.Benchmarks;

[MinLengthString(MinLength)]
public sealed partial record StaticMinLengthString
{
    public const int MinLength = 5;
}

[AttributeUsage(AttributeTargets.Class)]
public sealed class InstanceMinLengthStringAttribute(int minLength) : Attribute, IBaseTypeValidation<string>
{
    public void Validate(string value) => StringValidation.MinLength(minLength, value);
}

[InstanceMinLengthString(StaticMinLengthString.MinLength)] public sealed partial record InstanceMinLengthString;

[MemoryDiagnoser]
public class MinLengthStringBenchmark
{
    readonly string value = "teststring";

#pragma warning disable CA1806 // Do not ignore method results
    [Benchmark]
    public void WithInstanceMethod() => new InstanceMinLengthString(value);

    [Benchmark]
    public void WithStaticMethod() => new StaticMinLengthString(value);
#pragma warning restore CA1806 // Do not ignore method results
}
