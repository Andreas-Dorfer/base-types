using System;

namespace AD.BaseTypes
{
    /// <summary>
    /// Int wrapper.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class IntAttribute : Attribute, IBaseType<int>
    { }

    /// <summary>
    /// Double wrapper.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DoubleAttribute : Attribute, IBaseType<double>
    { }

    /// <summary>
    /// Decimal wrapper.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DecimalAttribute : Attribute, IBaseType<decimal>
    { }

    /// <summary>
    /// String wrapper.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class StringAttribute : Attribute, IBaseType<string>
    { }

    /// <summary>
    /// GUID wrapper.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class GuidAttribute : Attribute, IBaseType<Guid>
    { }

    /// <summary>
    /// DateTime wrapper.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DateTimeAttribute : Attribute, IBaseType<DateTime>
    { }
}
