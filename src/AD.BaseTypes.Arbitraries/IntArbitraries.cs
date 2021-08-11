using FsCheck;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for int base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class IntArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, int> where TBaseType : IValue<int>
    {
        /// <inheritdoc/>
        public IntArbitrary(Func<int, TBaseType> creator) : base(creator)
        { }

        /// <inheritdoc/>
        public static new IntArbitrary<TBaseType> Create(Func<int, TBaseType> creator) => new(creator);
    }

    /// <summary>
    /// Arbitrary for int base types with a minimal value.
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public class IntMinArbitrary<TBaseType> : IntArbitrary<TBaseType> where TBaseType : IValue<int>
    {
        /// <param name="min">The minimal value.</param>
        /// <param name="creator">The base type's creator.</param>
        public IntMinArbitrary(int min, Func<int, TBaseType> creator) : base(creator)
        {
            Min = min;
        }

        /// <summary>
        /// The minimal value.
        /// </summary>
        protected int Min { get; }

        /// <inheritdoc/>
        public override Gen<TBaseType> Generator =>
            Gen.Choose(Min, int.MaxValue).Select(Creator);

        /// <inheritdoc/>
        public override IEnumerable<TBaseType> Shrinker(TBaseType baseType) =>
            base.Shrinker(baseType).Where(_ => _.Value >= Min);

        /// <inheritdoc/>
        public static IntMinArbitrary<TBaseType> Create(int min, Func<int, TBaseType> creator) => new(min, creator);
    }
}
