using System;

namespace AD.BaseTypes
{
    /// <summary>
    /// Bool wrapper.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class BoolAttribute : Attribute, IBaseTypeDefinition<bool>
    { }
}
