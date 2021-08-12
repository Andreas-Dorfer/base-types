using AD.BaseTypes;

namespace TestApp
{
    [Int] partial record MyInt;

    [Double] partial record MyDouble;

    [Decimal] partial record MyDecimal;

    [String] partial record MyString;

    [Guid] partial record MyGuid;

    [DateTime] partial record MyDateTime;

    [IntMin(-100)] partial record MyIntMin;

    [IntMax(100)] partial record MyIntMax;

    [IntRange(-10, 10)] partial record MyIntRange;

    [PositiveDecimal] partial record MyPositiveDecimal;

    [NonEmptyString] partial record MyNonEmptyString;

    [MinLength(5)] partial record MyMinLength;

    [MaxLength(25)] partial record MyMaxLength;

    [MinMaxLength(10, 30)] partial record MinMaxLength;

    [Regex(@"\d\w")] partial record MyRegex;

    [NonEmptyGuid] partial record MyNonEmptyGuid;
}
