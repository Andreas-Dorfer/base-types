using FsCheck;
using System.Collections.Generic;
using System.Linq;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for non-empty string base types.
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public class NonEmptyStringArbitrary<TBaseType> : StringArbitrary<TBaseType> where TBaseType : IBaseType<string>
    {
        readonly Arbitrary<NonEmptyString> arb = Arb.Default.NonEmptyString();

        /// <summary>
        /// Filters empty string.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True, if the string isn't empty.</returns>
        protected override bool Filter(string value) => !string.IsNullOrEmpty(value);

        /// <summary>
        /// Maps a FsCheck.NonEmptyString to the base type.
        /// </summary>
        /// <param name="str">The FsCheck.NonEmptyString.</param>
        /// <returns>The base type.</returns>
        protected TBaseType Map(NonEmptyString str) => Creator(str.Item);

        /// <inheritdoc/>
        public override Gen<TBaseType> Generator => arb.Generator.Select(Map);

        /// <inheritdoc/>
        public override IEnumerable<TBaseType> Shrinker(TBaseType baseType) =>
            arb.Shrinker(NonEmptyString.NewNonEmptyString(baseType.Value)).Select(Map);
    }
}
