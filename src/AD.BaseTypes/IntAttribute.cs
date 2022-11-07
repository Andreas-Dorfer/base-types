namespace AD.BaseTypes;

/// <summary>
/// Int wrapper.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class IntAttribute : Attribute, IBaseTypeDefinition<int>
{ }
