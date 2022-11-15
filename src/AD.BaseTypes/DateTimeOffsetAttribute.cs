namespace AD.BaseTypes;

 
/// <summary>
/// DateTimeOffset wrapper.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class DateTimeOffsetAttribute : Attribute, IBaseTypeDefinition<DateTimeOffset>
{ }
