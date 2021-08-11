using FsCheck;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for string base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class StringArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, string> where TBaseType : IValue<string>
    {
        /// <inheritdoc/>
        public StringArbitrary(Func<string, TBaseType> creator) : base(creator)
        { }

        /// <inheritdoc/>
        public static new StringArbitrary<TBaseType> Create(Func<string, TBaseType> creator) => new(creator);
    }

    /// <summary>
    /// Arbitrary for non-empty string base types.
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public class NonEmptyStringArbitrary<TBaseType> : StringArbitrary<TBaseType> where TBaseType : IValue<string>
    {
        readonly Arbitrary<NonEmptyString> arb = Arb.Default.NonEmptyString();

        /// <inheritdoc/>
        public NonEmptyStringArbitrary(Func<string, TBaseType> creator) : base(creator)
        { }

        /// <summary>
        /// Maps a FsCheck.NonEmptyString to the base type.
        /// </summary>
        /// <param name="str">The FsCheck.NonEmptyString.</param>
        /// <returns>The base type.</returns>
        protected TBaseType Map(NonEmptyString str) => Creator(str.Item);

        /// <inheritdoc/>
        public override Gen<TBaseType> Generator =>
            arb.Generator.Select(Map);

        /// <inheritdoc/>
        public override IEnumerable<TBaseType> Shrinker(TBaseType baseType) =>
            arb.Shrinker(NonEmptyString.NewNonEmptyString(baseType.Value)).Select(Map);

        /// <inheritdoc/>
        public static new NonEmptyStringArbitrary<TBaseType> Create(Func<string, TBaseType> creator) => new(creator);
    }
}
