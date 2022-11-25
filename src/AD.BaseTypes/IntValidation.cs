namespace AD.BaseTypes;

static class IntValidation
{
    public static void Min(int min, int value, string paramName)
    {
        if (value < min) throw new ArgumentOutOfRangeException(paramName, value, $"'{paramName}' must be greater than or equal to {min}.");
    }

    public static void Max(int max, int value, string paramName)
    {
        if (value > max) throw new ArgumentOutOfRangeException(paramName, value, $"'{paramName}' must be less than or equal to {max}.");
    }
}
