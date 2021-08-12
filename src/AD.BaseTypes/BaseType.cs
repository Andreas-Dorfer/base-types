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
                    var creatorMethod = Expression.Call(methodInfo);
                    var creatorArg = Expression.Parameter(typeof(TWrapped));
                    creator = Expression.Lambda<Func<TWrapped, TBaseType>>(creatorMethod, creatorArg).Compile();
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
            get => creator ?? throw new InvalidOperationException($"Type '{typeof(TBaseType)}' does not define a creator.");
        }
    }
}
