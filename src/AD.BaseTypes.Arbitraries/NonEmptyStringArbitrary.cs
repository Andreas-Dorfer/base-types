using FsCheck;
using System.Collections.Generic;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for non-empty string base types.
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public class NonEmptyStringArbitrary<TBaseType> : Arbitrary<TBaseType> where TBaseType : IBaseType<string>
    {
        readonly Arbitrary<TBaseType> arb = Arb.Default.NonEmptyString().Convert(str => BaseType<TBaseType, string>.Create(str.Item), baseType => NonEmptyString.NewNonEmptyString(baseType.Value));

        /// <inheritdoc/>
        public override Gen<TBaseType> Generator => arb.Generator;

        /// <inheritdoc/>
        public override IEnumerable<TBaseType> Shrinker(TBaseType baseType) => arb.Shrinker(baseType);
    }
}
