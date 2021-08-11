using FsCheck;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AD.BaseTypes.FsCheck
{
    /// <summary>
    /// Arbitrary for int base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class IntArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, int> where TBaseType : IValue<int>
    {
        /// <inheritdoc/>
        public IntArbitrary(Func<int, TBaseType> create) : base(create)
        { }
    }

    /// <summary>
    /// Arbitrary for int base types with a minimal value.
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public class IntMinArbitrary<TBaseType> : IntArbitrary<TBaseType> where TBaseType : IValue<int>
    {
        /// <param name="min">The minimal value.</param>
        /// <param name="create">The base type's creator.</param>
        public IntMinArbitrary(int min, Func<int, TBaseType> create) : base(create)
        {
            Min = min;
        }

        /// <summary>
        /// The minimal value.
        /// </summary>
        protected int Min { get; }

        /// <inheritdoc/>
        public override Gen<TBaseType> Generator =>
            Gen.Choose(Min, int.MaxValue).Select(Create);

        /// <inheritdoc/>
        public override IEnumerable<TBaseType> Shrinker(TBaseType baseType) =>
            base.Shrinker(baseType).Where(_ => _.Value >= Min);
    }
}
