using System;

namespace AD.BaseTypes
{
    /// <summary>
    /// Int wrapper.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class IntAttribute : Attribute, IBaseTypeDefinition<int>
    { }
}
