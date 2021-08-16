using FsCheck;
using System;
using System.Collections.Generic;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for string base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class StringArbitrary<TBaseType> : Arbitrary<TBaseType> where TBaseType : IBaseType<string>
    {
        readonly Arbitrary<TBaseType> arb;

        /// <summary>
        /// Creates the arbitrary.
        /// </summary>
        public StringArbitrary()
        {
            arb = Arb.Default.NonNull<string>().Filter(str => Filter(str.Item)).Convert(str => Creator(str.Item), baseType => NonNull<string>.NewNonNull(baseType.Value));
        }

        /// <summary>
        /// The base type's creator.
        /// </summary>
        /// <param name="value">The wrapped value.</param>
        /// <returns>The base type.</returns>
        /// <exception cref="NotImplementedException">The base type does not define a creator.</exception>
        /// <exception cref="ArgumentException">The parameter <paramref name="value"/> is invalid.</exception>
        protected TBaseType Creator(string value) => BaseType<TBaseType, string>.Create(value);

        /// <summary>
        /// Filters null.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True, if the string is not null.</returns>
        protected virtual bool Filter(string value) => value is not null;

        /// <inheritdoc/>
        public override Gen<TBaseType> Generator => arb.Generator;

        /// <inheritdoc/>
        public override IEnumerable<TBaseType> Shrinker(TBaseType baseType) => arb.Shrinker(baseType);
    }
}
