namespace AD.BaseTypes;

/// <summary>
/// Double wrapper.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class DoubleAttribute : Attribute, IBaseTypeDefinition<double>
{ }
