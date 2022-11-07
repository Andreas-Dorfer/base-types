namespace AD.BaseTypes;

/// <summary>
/// Guid wrapper.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class GuidAttribute : Attribute, IBaseTypeDefinition<Guid>
{ }
