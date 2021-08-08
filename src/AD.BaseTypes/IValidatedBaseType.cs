using System;

namespace AD.BaseTypes
{
    /// <summary>
    /// A validated wrapper around a (primitive) type.
    /// </summary>
    /// <typeparam name="T">The type to wrap.</typeparam>
    public interface IValidatedBaseType<T> : IBaseType<T>
    {
        /// <summary>
        /// Validates the wrapped value.
        /// </summary>
        /// <param name="value">The value to be validated.</param>
        /// <exception cref="ArgumentException">The parameter <paramref name="value"/> is invalid.</exception>
        void Validate(T value);

        /// <summary>
        /// The validation's precedence.
        /// </summary>
        int Order => 0;
    }
}
