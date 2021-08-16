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
    public class BaseTypeArbitrary<TBaseType, TWrapped> : Arbitrary<TBaseType> where TBaseType : IBaseType<TWrapped>
    {
        readonly Arbitrary<TWrapped> arb;

        /// <summary>
        /// Creates the arbitrary.
        /// </summary>
        public BaseTypeArbitrary()
        {
            arb = Arb.From<TWrapped>().Filter(Filter);
        }

        /// <summary>
        /// The base type's creator.
        /// </summary>
        /// <param name="value">The wrapped value.</param>
        /// <returns>The base type.</returns>
        /// <exception cref="NotImplementedException">The base type does not define a creator.</exception>
        /// <exception cref="ArgumentException">The parameter <paramref name="value"/> is invalid.</exception>
        protected TBaseType Creator(TWrapped value) => BaseType<TBaseType, TWrapped>.Create(value);

        /// <summary>
        /// Filters invalid wrapped values.
        /// </summary>
        /// <param name="value">The wrapped value to check.</param>
        /// <returns>True, if the wrapped value is valid.</returns>
        protected virtual bool Filter(TWrapped value) => true;

        /// <summary>
        /// Generates the base type.
        /// </summary>
        public override Gen<TBaseType> Generator => arb.Generator.Select(Creator);

        /// <summary>
        /// Shrinks the base type.
        /// </summary>
        /// <param name="baseType"></param>
        /// <returns></returns>
        public override IEnumerable<TBaseType> Shrinker(TBaseType baseType) => arb.Shrinker(baseType.Value).Select(Creator);
    }
}
