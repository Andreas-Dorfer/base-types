namespace AD.BaseTypes;

/// <summary>
/// Int with a minimal value.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class MinIntAttribute : Attribute, IStaticBaseTypeValidation<int>
{
#pragma warning disable IDE0060 // Remove unused parameter
    /// <param name="min">Minimal value.</param>
    public MinIntAttribute(int min)
    { }
#pragma warning restore IDE0060 // Remove unused parameter

    /// <param name="value">The value to be validated.</param>
    /// <param name="min">Minimal value.</param>
    /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is too small.</exception>
    public static void Validate(int value, int min) => IntValidation.Min(min, value);
}
