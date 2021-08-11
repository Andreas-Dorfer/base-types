using FsCheck;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AD.BaseTypes.FsCheck
{
    /// <summary>
    /// Arbitrary for GUID base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class GuidArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, Guid> where TBaseType : IValue<Guid>
    {
        /// <inheritdoc/>
        public GuidArbitrary(Func<Guid, TBaseType> create) : base(create)
        { }
    }

    /// <summary>
    /// Arbitrary for non-empty GUID base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class NonEmptyGuidArbitrary<TBaseType> : GuidArbitrary<TBaseType> where TBaseType : IValue<Guid>
    {
        readonly Arbitrary<Guid> arb = Arb.Default.Guid();

        /// <inheritdoc/>
        public NonEmptyGuidArbitrary(Func<Guid, TBaseType> create) : base(create)
        { }

        /// <summary>
        /// Filters empty guids.
        /// </summary>
        /// <param name="guid">The guid to filter.</param>
        /// <returns>True, if the guid is not empty.</returns>
        protected static bool Filter(Guid guid) => guid != Guid.Empty;

        /// <inheritdoc/>
        public override Gen<TBaseType> Generator =>
            arb.Generator.Where(Filter).Select(Create);

        /// <inheritdoc/>
        public override IEnumerable<TBaseType> Shrinker(TBaseType baseType) =>
            arb.Shrinker(baseType.Value).Where(Filter).Select(Create);
    }
}
