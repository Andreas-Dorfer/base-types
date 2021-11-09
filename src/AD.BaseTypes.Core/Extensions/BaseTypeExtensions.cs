using System.Diagnostics.CodeAnalysis;

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
        /// Tries to map a base type.
        /// </summary>
        /// <typeparam name="TBaseType">The base type.</typeparam>
        /// <typeparam name="TWrapped">The wrapped type.</typeparam>
        /// <param name="baseType">The base type.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="mapped">The mapped base type.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>True, if the base type is created.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="baseType"/> or <paramref name="mapper"/> is null.</exception>
        /// <exception cref="NotImplementedException">The base type does not define a creator.</exception>
        public static bool TryMap<TBaseType, TWrapped>(this TBaseType baseType, Func<TWrapped, TWrapped> mapper, [MaybeNullWhen(false)] out TBaseType mapped, [MaybeNullWhen(true)] out string errorMessage) where TBaseType : IBaseType<TWrapped>
        {
            if (baseType is null) throw new ArgumentNullException(nameof(baseType));
            if (mapper is null) throw new ArgumentNullException(nameof(mapper));

            return BaseType<TBaseType, TWrapped>.TryCreate(mapper(baseType.Value), out mapped, out errorMessage);
        }

        /// <summary>
        /// Maps a base type's value.
        /// </summary>
        /// <typeparam name="TWrapped">The wrapped type.</typeparam>
        /// <param name="baseType">The base type.</param>
        /// <param name="mapper">The mapper.</param>
        /// <returns>The mapped value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="baseType"/> or <paramref name="mapper"/> is null.</exception>
        public static TWrapped MapValue<TWrapped>(this IBaseType<TWrapped> baseType, Func<TWrapped, TWrapped> mapper)
        {
            if (baseType is null) throw new ArgumentNullException(nameof(baseType));
            if (mapper is null) throw new ArgumentNullException(nameof(mapper));

            return mapper(baseType.Value);
        }

        /// <summary>
        /// Gets a base type's value.
        /// </summary>
        /// <typeparam name="TWrapped">The wrapped type.</typeparam>
        /// <param name="baseType">The base type.</param>
        /// <returns>The base type's value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="baseType"/> is null.</exception>
        public static TWrapped Value<TWrapped>(this IBaseType<TWrapped> baseType)
        {
            if (baseType is null) throw new ArgumentNullException(nameof(baseType));

            return baseType.Value;
        }
    }
}
