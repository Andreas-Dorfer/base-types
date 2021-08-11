using FsCheck;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    /// <typeparam name="TWrapped">The wrapped type.</typeparam>
    public class BaseTypeArbitrary<TBaseType, TWrapped> : Arbitrary<TBaseType> where TBaseType : IValue<TWrapped>
    {
        /// <param name="create">The base type's creator.</param>
        /// <exception cref="ArgumentNullException">The creator is null.</exception>
        public BaseTypeArbitrary(Func<TWrapped, TBaseType> create)
        {
            Create = create ?? throw new ArgumentNullException(nameof(create));
        }

        /// <summary>
        /// The base type's creator.
        /// </summary>
        protected Func<TWrapped, TBaseType> Create { get; }

        /// <summary>
        /// Generates the base type.
        /// </summary>
        public override Gen<TBaseType> Generator =>
            Arb.Generate<TWrapped>().Select(Create);

        /// <summary>
        /// Shrinks the base type.
        /// </summary>
        /// <param name="baseType"></param>
        /// <returns></returns>
        public override IEnumerable<TBaseType> Shrinker(TBaseType baseType) =>
            Arb.Shrink(baseType.Value).Select(Create);
    }
}
