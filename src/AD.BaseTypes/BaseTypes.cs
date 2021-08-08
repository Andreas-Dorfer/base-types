using System;

namespace AD.BaseTypes
{
    /// <summary>
    /// Int-Wrapper.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class IntAttribute : Attribute, IBaseType<int>
    { }

    /// <summary>
    /// String-Wrapper.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class StringAttribute : Attribute, IBaseType<string>
    { }

    /// <summary>
    /// GUID-Wrapper.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class GuidAttribute : Attribute, IBaseType<Guid>
    { }

    /// <summary>
    /// Decimal-Wrapper.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DecimalAttribute : Attribute, IBaseType<decimal>
    { }
}
