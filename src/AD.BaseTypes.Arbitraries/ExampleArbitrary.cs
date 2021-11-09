namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Example based arbitrary.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    /// <typeparam name="TWrapped">The wrapped type.</typeparam>
    public class ExampleArbitrary<TBaseType, TWrapped> : Arbitrary<TBaseType> where TBaseType : IBaseType<TWrapped>
    {
        readonly TWrapped[] examples;

        /// <summary>
        /// Creates the arbitrary.
        /// </summary>
        /// <param name="examples">The examples to use.</param>
        /// <exception cref="ArgumentNullException">The parameter <paramref name="examples"/> is null.</exception>
        public ExampleArbitrary(params TWrapped[] examples)
        {
            this.examples = examples ?? throw new ArgumentNullException(nameof(examples));
        }

        /// <inheritdoc/>
        public override Gen<TBaseType> Generator => Gen.Elements(examples).Select(BaseType<TBaseType, TWrapped>.Create);
    }
}
