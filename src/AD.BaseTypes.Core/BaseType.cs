using System;
using System.Linq.Expressions;
using System.Reflection;

namespace AD.BaseTypes
{
    /// <summary>
    /// Base type.
    /// </summary>
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
        /// The base type's creator.
        /// </summary>
        /// <exception cref="InvalidOperationException">The base type does not define a creator.</exception>
        public static Func<TWrapped, TBaseType> Creator
        {
            get => creator ?? throw new InvalidOperationException($"The type '{typeof(TBaseType)}' does not define a creator.");
        }
    }
}
