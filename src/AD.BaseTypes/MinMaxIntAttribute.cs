namespace AD.BaseTypes;

/// <summary>
/// Int within a range.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public sealed class MinMaxIntAttribute : Attribute, IStaticBaseTypeValidation<int>
{
#pragma warning disable IDE0060 // Remove unused parameter
    /// <param name="min">Minimal value.</param>
    /// <param name="max">Maximal value.</param>
    public MinMaxIntAttribute(int min, int max)
    { }
#pragma warning restore IDE0060 // Remove unused parameter

    /// <param name="value">The value to be validated.</param>
    /// <param name="min">Minimal value.</param>
    /// <param name="max">Maximal value.</param>
    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is too small or too large.</exception>
    public static void Validate(int value, int min, int max)
    {
        IntValidation.Min(min, value);
        IntValidation.Max(max, value);
    }
}
