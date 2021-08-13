using System;
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
        static readonly Func<TWrapped, TBaseType>? creator;

        static BaseType()
        {
            try
            {
                var methodInfo = typeof(TBaseType).GetMethod("Create", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(TWrapped) }, null);
                if (methodInfo is not null)
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
        /// <exception cref="NotImplementedException">The base type does not define a creator.</exception>
        /// <exception cref="ArgumentException">The parameter <paramref name="value"/> is invalid.</exception>
        public static TBaseType Create(TWrapped value)
        {
            if (creator is null) throw new NotImplementedException($"The type '{typeof(TBaseType)}' does not define a creator.");
            return creator(value);
        }
    }
}
