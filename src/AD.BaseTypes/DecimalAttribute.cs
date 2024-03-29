﻿namespace AD.BaseTypes;

/// <summary>
/// Decimal wrapper.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class DecimalAttribute : Attribute, IBaseTypeDefinition<decimal>
{ }
