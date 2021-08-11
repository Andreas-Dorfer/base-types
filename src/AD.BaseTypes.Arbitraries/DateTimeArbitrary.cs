using System;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for DateTime base types.
    /// </summary>
    public static class DateTimeArbitrary
    {
        /// <summary>
        /// Creates an arbitrary.
        /// </summary>
        /// <typeparam name="TBaseType">The base type.</typeparam>
        /// <param name="creator">The base type's creator.</param>
        /// <returns>The arbitrary.</returns>
        public static DateTimeArbitrary<TBaseType> Create<TBaseType>(Func<DateTime, TBaseType> creator) where TBaseType : IValue<DateTime> => new(creator);
    }

    /// <summary>
    /// Arbitrary for DateTime base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class DateTimeArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, DateTime> where TBaseType : IValue<DateTime>
    {
        /// <inheritdoc/>
        public DateTimeArbitrary(Func<DateTime, TBaseType> creator) : base(creator)
        { }
    }
}
