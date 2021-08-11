using System;

namespace AD.BaseTypes
{
    /// <summary>
    /// String wrapper.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class StringAttribute : Attribute, IBaseType<string>
    { }
}
