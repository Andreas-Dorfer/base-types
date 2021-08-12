using System;

namespace AD.BaseTypes
{
    /// <summary>
    /// Double wrapper.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DoubleAttribute : Attribute, IBaseTypeDefinition<double>
    { }
}
