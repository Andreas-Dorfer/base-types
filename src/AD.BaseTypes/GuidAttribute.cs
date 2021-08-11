using System;

namespace AD.BaseTypes
{
    /// <summary>
    /// GUID wrapper.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class GuidAttribute : Attribute, IBaseType<Guid>
    { }
}
