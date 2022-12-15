using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace AD.BaseTypes.Benchmarks;

[RegexString(Pattern)]
public sealed partial record StaticRegexString
{
    public const string Pattern = @"\d\d\w\w";
}

[AttributeUsage(AttributeTargets.Class)]
public sealed class InstanceRegexStringAttribute : Attribute, IBaseTypeValidation<string>
{
    readonly string pattern;

    public InstanceRegexStringAttribute([StringSyntax(StringSyntaxAttribute.Regex)] string pattern)
    {
        this.pattern = pattern;
    }

    public void Validate(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (!Regex.IsMatch(value, pattern)) throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter doesn't match the pattern '{pattern}'.");
    }
}

[InstanceRegexString(StaticRegexString.Pattern)] public sealed partial record InstanceRegexString;

[MemoryDiagnoser]
public class RegexStringBenchmark
{
    readonly string value = "42xy";

#pragma warning disable CA1806 // Do not ignore method results
    [Benchmark]
    public void WithInstanceMethod() => new InstanceRegexString(value);

    [Benchmark]
    public void WithStaticMethod() => new StaticRegexString(value);
#pragma warning restore CA1806 // Do not ignore method results
}
