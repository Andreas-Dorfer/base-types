namespace AD.BaseTypes;

static class StringValidation
{
    public static void MinLength(int minLength, string value, string baseTypeName)
    {
        ArgumentNullException.ThrowIfNull(value, baseTypeName);
        if (value.Length < minLength) throw new ArgumentOutOfRangeException(baseTypeName, value, $"'{baseTypeName}' must be at least {minLength} character(s) long.");
    }

    public static void MaxLength(int maxLength, string value, string baseTypeName)
    {
        ArgumentNullException.ThrowIfNull(value, baseTypeName);
        if (value.Length > maxLength) throw new ArgumentOutOfRangeException(baseTypeName, value, $"'{baseTypeName}' must not be no longer than {maxLength} character(s).");
    }
}
