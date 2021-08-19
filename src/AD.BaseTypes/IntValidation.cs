using System;

namespace AD.BaseTypes
{
    static class IntValidation
    {
        public static void Min(int min, int value)
        {
            if (value < min) throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter must be greater than or equal to {min}.");
        }

        public static void Max(int max, int value)
        {
            if (value > max) throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter must be less than or equal to {max}.");
        }
    }
}
