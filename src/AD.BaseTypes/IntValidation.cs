using System;

namespace AD.BaseTypes
{
    static class IntValidation
    {
        public static void Min(int min, int value)
        {
            if (value < min) throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter must be more than {min}.");
        }

        public static void Max(int max, int value)
        {
            if (value > max) throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter must be less than {max}.");
        }
    }
}
