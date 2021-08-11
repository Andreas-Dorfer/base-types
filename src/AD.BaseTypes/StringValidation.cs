using System;

namespace AD.BaseTypes
{
    static class StringValidation
    {
        public static void MinLength(int minLength, string value)
        {
            if (value is null || value.Length < minLength) throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter must be at least {minLength} character(s) long.");
        }

        public static void MaxLength(int maxLength, string value)
        {
            if (value is null || value.Length > maxLength) throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter must not be no longer than {maxLength} character(s).");
        }
    }
}
