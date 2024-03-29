﻿namespace AD.BaseTypes.Benchmarks;

[MaxInt(Max)]
public sealed partial record StaticMaxInt
{
    public const int Max = 100;
}

[AttributeUsage(AttributeTargets.Class)]
public sealed class InstanceMaxIntAttribute(int max) : Attribute, IBaseTypeValidation<int>
{

    public void Validate(int value) => IntValidation.Max(max, value);
}

[InstanceMaxInt(StaticMaxInt.Max)] public sealed partial record InstanceMaxInt;

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
