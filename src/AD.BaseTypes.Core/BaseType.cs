using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace AD.BaseTypes
{
    /// <summary>
    /// Base type.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    /// <typeparam name="TWrapped">The wrapped type.</typeparam>
    public static class BaseType<TBaseType, TWrapped> where TBaseType : IBaseType<TWrapped>
    {
        static readonly Func<TWrapped, TBaseType> creator = _ => throw new NotImplementedException($"The type '{typeof(TBaseType)}' does not define a creator.");

        static BaseType()
        {
            try
            {
                var methodInfo = typeof(TBaseType).GetMethod("Create", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(TWrapped) }, null);
                if (methodInfo is not null && methodInfo.ReturnType == typeof(TBaseType))
                {
                    var arg = Expression.Parameter(typeof(TWrapped));
                    var method = Expression.Call(methodInfo, arg);
                    creator = Expression.Lambda<Func<TWrapped, TBaseType>>(method, arg).Compile();
                }
            }
            catch { }
        }

        /// <summary>
        /// Creates the base type.
        /// </summary>
        /// <param name="value">The wrapped value.</param>
        /// <returns>The created base type.</returns>
        /// <exception cref="NotImplementedException">The base type does not define a creator.</exception>
        /// <exception cref="ArgumentException">The parameter <paramref name="value"/> is invalid.</exception>
        public static TBaseType Create(TWrapped value) => creator(value);

        /// <summary>
        /// Tries to create a base type.
        /// </summary>
        /// <param name="value">The wrapped value.</param>
        /// <param name="baseType">The created base type.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>True, if the base type is created.</returns>
        /// <exception cref="NotImplementedException">The base type does not define a creator.</exception>
        public static bool TryCreate(TWrapped value, [MaybeNullWhen(false)] out TBaseType baseType, [MaybeNullWhen(true)] out string errorMessage)
        {
            try
            {
                baseType = Create(value);
                errorMessage = default;
                return true;
            }
            catch (ArgumentException ex)
            {
                baseType = default;
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
