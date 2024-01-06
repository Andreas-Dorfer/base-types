namespace AD.BaseTypes;

/// <summary>
/// Int with a minimal value.
/// </summary>
/// <param name="min">Minimal value.</param>
[AttributeUsage(AttributeTargets.Class)]
#pragma warning disable CS9113 // Parameter is unread.
public sealed class MinIntAttribute(int min) : Attribute, IStaticBaseTypeValidation<int>
#pragma warning restore CS9113 // Parameter is unread.
{
    /// <param name="value">The value to be validated.</param>
    /// <param name="min">Minimal value.</param>
    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is too small.</exception>
    public static void Validate(int value, int min) => IntValidation.Min(min, value);
}
