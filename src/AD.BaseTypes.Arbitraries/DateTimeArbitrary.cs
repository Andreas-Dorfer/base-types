using System;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for DateTime base types.
    /// </summary>
    /// <typeparam name="TBaseType">The base type.</typeparam>
    public class DateTimeArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, DateTime> where TBaseType : IBaseType<DateTime>
    { }
}
