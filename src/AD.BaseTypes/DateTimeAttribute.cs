namespace AD.BaseTypes;

/// <summary>
/// DateTime wrapper.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class DateTimeAttribute : Attribute, IBaseTypeDefinition<DateTime>
{ }
