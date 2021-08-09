namespace AD.BaseTypes.Common
{
    /// <summary>
    /// A GUID that's never empty.
    /// </summary>
    [NonEmptyGuid] public partial record NonEmptyGuid;

    /// <summary>
    /// A string that's never null or empty.
    /// </summary>
    [NonEmptyString] public partial record NonEmptySting;

    /// <summary>
    /// A decimal that's never negative.
    /// </summary>
    [PositiveDecimal] public partial record PositiveDecimal;
}
