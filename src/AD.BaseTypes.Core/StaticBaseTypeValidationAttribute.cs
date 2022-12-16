namespace AD.BaseTypes;

[AttributeUsage(AttributeTargets.Class)]
public sealed class StaticBaseTypeValidationAttribute<TWrapped> : Attribute where TWrapped : notnull
{ }
