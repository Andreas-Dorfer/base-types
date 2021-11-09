namespace AD.BaseTypes
{
    /// <summary>
    /// String with a minimal and maximal length.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MinMaxLengthStringAttribute : Attribute, IBaseTypeValidation<string>
    {
        readonly int minLength, maxLength;

        /// <param name="minLength">Minimal length.</param>
        /// <param name="maxLength">Maximal length.</param>
        public MinMaxLengthStringAttribute(int minLength, int maxLength)
        {
            this.minLength = minLength;
            this.maxLength = maxLength;
        }

        /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is too short or too long.</exception>
        public void Validate(string value)
        {
            StringValidation.MinLength(minLength, value);
            StringValidation.MaxLength(maxLength, value);
        }
    }
}
