namespace AD.BaseTypes
{
    /// <summary>
    /// String with a minimal length.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MinLengthStringAttribute : Attribute, IBaseTypeValidation<string>
    {
        readonly int minLength;

        /// <param name="minLength">Minimal length.</param>
        public MinLengthStringAttribute(int minLength)
        {
            this.minLength = minLength;
        }

        /// <exception cref="ArgumentOutOfRangeException">The parameter <paramref name="value"/> is too short.</exception>
        public void Validate(string value) => StringValidation.MinLength(minLength, value);
    }
}
