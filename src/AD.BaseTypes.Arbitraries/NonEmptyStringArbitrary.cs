namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for non-empty string base types.
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public class NonEmptyStringArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, string> where TBaseType : IBaseType<string>
    {
        /// <inheritdoc/>
        protected override Arbitrary<string> WrappedArb() => Arb.Default.NonEmptyString().Convert(str => str.Item, str => NonEmptyString.NewNonEmptyString(str));

        /// <summary>
        /// Filters empty strings.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True, if the string is valid.</returns>
        protected override bool Filter(string value) => !string.IsNullOrEmpty(value);
    }
}
