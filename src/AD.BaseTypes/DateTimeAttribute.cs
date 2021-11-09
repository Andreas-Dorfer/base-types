namespace AD.BaseTypes
{
    /// <summary>
    /// DateTime wrapper.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DateTimeAttribute : Attribute, IBaseTypeDefinition<DateTime>
    { }
}
