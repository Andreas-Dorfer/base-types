using FsCheck;
using System.Collections.Generic;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for string base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class StringArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, string> where TBaseType : IBaseType<string>
    {
        readonly Arbitrary<TBaseType> arb;

        /// <summary>
        /// Creates a <see cref="StringArbitrary{TBaseType}"/>.
        /// </summary>
        public StringArbitrary()
        {
            arb = Arb.Default.NonNull<string>().Convert(str => Creator(str.Item), baseType => NonNull<string>.NewNonNull(baseType.Value));
        }

        /// <summary>
        /// Filters empty strings.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True, if the string isn't empty.</returns>
        protected override bool Filter(string value) => value is not null;

        /// <inheritdoc/>
        public override Gen<TBaseType> Generator => arb.Generator;

        /// <inheritdoc/>
        public override IEnumerable<TBaseType> Shrinker(TBaseType baseType) => arb.Shrinker(baseType);
    }
}
