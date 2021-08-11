using System;

namespace AD.BaseTypes
{
    /// <summary>
    /// Non-empty string.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class NonEmptyStringAttribute : Attribute, IValidatedBaseType<string>
    {
        /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is empty.</exception>
        public void Validate(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentOutOfRangeException(nameof(value), value, "Parameter must not be empty.");
        }
    }
}
