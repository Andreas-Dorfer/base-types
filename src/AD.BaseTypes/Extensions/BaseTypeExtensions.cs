using System;

namespace AD.BaseTypes.Extensions
{
    /// <summary>
    /// Base type extensions.
    /// </summary>
    public static class BaseTypeExtensions
    {
        /// <summary>
        /// Maps a base type.
        /// </summary>
        /// <typeparam name="TBaseType">The base type.</typeparam>
        /// <typeparam name="TWrapped">The wrapped type.</typeparam>
        /// <param name="baseType">The base type.</param>
        /// <param name="mapper">The mapper.</param>
        /// <returns>The mapped base type.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="baseType"/> or <paramref name="mapper"/> is null.</exception>
        /// <exception cref="NotImplementedException">The base type does not define a creator.</exception>
        /// <exception cref="ArgumentException">The mapped value is invalid.</exception>
        public static TBaseType Map<TBaseType, TWrapped>(this TBaseType baseType, Func<TWrapped, TWrapped> mapper) where TBaseType : IBaseType<TWrapped>
        {
            if (baseType is null) throw new ArgumentNullException(nameof(baseType));
            if (mapper is null) throw new ArgumentNullException(nameof(mapper));

            return BaseType<TBaseType, TWrapped>.Create(mapper(baseType.Value));
        }

        /// <summary>
        /// Maps a base type's value.
        /// </summary>
        /// <typeparam name="TBaseType">The base type.</typeparam>
        /// <typeparam name="TWrapped">The wrapped type.</typeparam>
        /// <param name="baseType">The base type.</param>
        /// <param name="mapper">The mapper.</param>
        /// <returns>The mapped value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="baseType"/> or <paramref name="mapper"/> is null.</exception>
        public static TWrapped MapValue<TBaseType, TWrapped>(this TBaseType baseType, Func<TWrapped, TWrapped> mapper) where TBaseType : IBaseType<TWrapped>
        {
            if (baseType is null) throw new ArgumentNullException(nameof(baseType));
            if (mapper is null) throw new ArgumentNullException(nameof(mapper));

            return mapper(baseType.Value);
        }
    }
}
