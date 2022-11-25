namespace AD.BaseTypes;

static class StringValidation
{
    public static void MinLength(int minLength, string value, string paramName)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value.Length < minLength) throw new ArgumentOutOfRangeException(paramName, value, $"'{paramName}' must be at least {minLength} character(s) long.");
    }

    public static void MaxLength(int maxLength, string value, string paramName)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value.Length > maxLength) throw new ArgumentOutOfRangeException(paramName, value, $"'{paramName}' must not be no longer than {maxLength} character(s).");
    }
}
