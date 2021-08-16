using FsCheck;
using System.Collections.Generic;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for non-empty string base types.
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public class NonEmptyStringArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, string> where TBaseType : IBaseType<string>
    {
        readonly Arbitrary<TBaseType> arb;

        /// <summary>
        /// Creates a <see cref="NonEmptyStringArbitrary{TBaseType}"/>.
        /// </summary>
        public NonEmptyStringArbitrary()
        {
            arb = Arb.Default.NonEmptyString().Convert(str => Creator(str.Item), baseType => NonEmptyString.NewNonEmptyString(baseType.Value));
        }

        /// <summary>
        /// Filters empty string.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True, if the string isn't empty.</returns>
        protected override bool Filter(string value) => !string.IsNullOrEmpty(value);

        /// <inheritdoc/>
        public override Gen<TBaseType> Generator => arb.Generator;

        /// <inheritdoc/>
        public override IEnumerable<TBaseType> Shrinker(TBaseType baseType) => arb.Shrinker(baseType);
    }
}
