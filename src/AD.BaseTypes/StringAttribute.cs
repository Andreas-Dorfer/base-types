namespace AD.BaseTypes
{
    /// <summary>
    /// Non-null string wrapper.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class StringAttribute : Attribute, IBaseTypeValidation<string>
    {
        /// <exception cref="ArgumentNullException">The parameter <paramref name="value"/> is null.</exception>
        public void Validate(string value)
        {
            if (value is null) throw new ArgumentNullException(nameof(value), "Parameter must not be null.");
        }
    }
}
