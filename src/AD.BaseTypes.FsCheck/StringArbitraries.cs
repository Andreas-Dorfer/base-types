using FsCheck;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AD.BaseTypes.FsCheck
{
    /// <summary>
    /// Arbitrary for string base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class StringArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, string> where TBaseType : IValue<string>
    {
        /// <inheritdoc/>
        public StringArbitrary(Func<string, TBaseType> create) : base(create)
        { }
    }

    /// <summary>
    /// Arbitrary for non-empty string base types.
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public class NonEmptyStringArbitrary<TBaseType> : StringArbitrary<TBaseType> where TBaseType : IValue<string>
    {
        readonly Arbitrary<NonEmptyString> arb = Arb.Default.NonEmptyString();

        /// <inheritdoc/>
        public NonEmptyStringArbitrary(Func<string, TBaseType> create) : base(create)
        { }

        /// <summary>
        /// Maps a FsCheck.NonEmptyString to the base type.
        /// </summary>
        /// <param name="str">The FsCheck.NonEmptyString.</param>
        /// <returns>The base type.</returns>
        protected TBaseType Map(NonEmptyString str) => Create(str.Item);

        /// <inheritdoc/>
        public override Gen<TBaseType> Generator =>
            arb.Generator.Select(Map);

        /// <inheritdoc/>
        public override IEnumerable<TBaseType> Shrinker(TBaseType baseType) =>
            arb.Shrinker(NonEmptyString.NewNonEmptyString(baseType.Value)).Select(Map);
    }
}
