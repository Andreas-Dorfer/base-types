namespace AD.BaseTypes;

static class IntValidation
{
    public static void Min(int min, int value, string baseTypeName)
    {
        if (value < min) throw new ArgumentOutOfRangeException(baseTypeName, value, $"'{baseTypeName}' must be greater than or equal to {min}.");
    }

    public static void Max(int max, int value, string baseTypeName)
    {
        if (value > max) throw new ArgumentOutOfRangeException(baseTypeName, value, $"'{baseTypeName}' must be less than or equal to {max}.");
    }
}
