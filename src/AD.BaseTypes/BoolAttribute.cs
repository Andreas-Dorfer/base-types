namespace AD.BaseTypes;

/// <summary>
/// Bool wrapper.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class BoolAttribute : Attribute, IBaseTypeDefinition<bool>
{ }
