using System;

namespace AD.BaseTypes
{
    /// <summary>
    /// Non-empty GUID.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class NonEmptyGuidAttribute : Attribute, IBaseTypeValidation<Guid>
    {
        /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is empty.</exception>
        public void Validate(Guid value)
        {
            if (value == Guid.Empty) throw new ArgumentOutOfRangeException(nameof(value), value, "Parameter must not be empty.");
        }
    }
}
