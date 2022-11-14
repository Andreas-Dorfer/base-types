namespace AD.BaseTypes.Arbitraries;

public class DateTimeOffsetArbitrary
{
    
}

/// <summary>
/// Arbitrary for DateTimeOffset base types.
/// </summary>
/// <typeparam name="TBaseType">The base type.</typeparam>
public class DateTimeOffsetArbitrary<TBaseType> : BaseTypeArbitrary<TBaseType, DateTimeOffset> where TBaseType : IBaseType<DateTimeOffset>
{ }
