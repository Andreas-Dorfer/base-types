namespace AD.BaseTypes;

/// <summary>
/// Int with a maximal value.
/// </summary>
/// <param name="max">Maximal value.</param>
[AttributeUsage(AttributeTargets.Class)]
#pragma warning disable CS9113 // Parameter is unread.
public sealed class MaxIntAttribute(int max) : Attribute, IStaticBaseTypeValidation<int>
#pragma warning restore CS9113 // Parameter is unread.
{
    /// <param name="value">The value to be validated.</param>
    /// <param name="max">Maximal value.</param>
    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is too large.</exception>
    public static void Validate(int value, int max) => IntValidation.Max(max, value);
}
