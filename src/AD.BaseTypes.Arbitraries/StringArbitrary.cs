using FsCheck;
using System.Collections.Generic;
using System.Linq;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for string base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class StringArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, string> where TBaseType : IBaseType<string>
    {
        readonly Arbitrary<NonNull<string>> arb = Arb.Default.NonNull<string>();

        /// <summary>
        /// Filters empty strings.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True, if the string isn't empty.</returns>
        protected override bool Filter(string value) => value is not null;

        /// <summary>
        /// Maps a NonNull-string to the base type.
        /// </summary>
        /// <param name="str">The NonNull-string.</param>
        /// <returns>The base type.</returns>
        protected TBaseType Map(NonNull<string> str) => Creator(str.Item);

        /// <inheritdoc/>
        public override Gen<TBaseType> Generator => arb.Generator.Select(Map);

        /// <inheritdoc/>
        public override IEnumerable<TBaseType> Shrinker(TBaseType baseType) =>
            arb.Shrinker(NonNull<string>.NewNonNull(baseType.Value)).Select(Map);
    }
}
