namespace AD.BaseTypes
{
    /// <summary>
    /// Arguments to the source generator.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class BaseTypeAttribute : Attribute
    {
        /// <summary>
        /// Arguments to the source generator.
        /// </summary>
        /// <param name="cast">The generated cast operator.</param>
        public BaseTypeAttribute(Cast cast)
        {
            Cast = cast;
        }

        /// <summary>
        /// The generated cast operator.
        /// </summary>
        public Cast Cast { get; }
    }
}
