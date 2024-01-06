namespace AD.BaseTypes;

/// <summary>
/// Int within a range.
/// </summary>
/// <param name="min">Minimal value.</param>
/// <param name="max">Maximal value.</param>
[AttributeUsage(AttributeTargets.Class)]
#pragma warning disable CS9113 // Parameter is unread.
public sealed class MinMaxIntAttribute(int min, int max) : Attribute, IStaticBaseTypeValidation<int>
#pragma warning restore CS9113 // Parameter is unread.
{
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
