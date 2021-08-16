using AD.BaseTypes;

namespace TestApp
{
    [Int] public partial record MyInt;

    [Double] public partial record MyDouble;

    [Decimal] public partial record MyDecimal;

    [String] public partial record MyString;

    [Guid] public partial record MyGuid;

    [DateTime] public partial record MyDateTime;

    [IntMin(-100)] public partial record MyIntMin;

    [IntMax(100)] public partial record MyIntMax;

    [IntRange(-10, 10)] public partial record MyIntRange;

    [PositiveDecimal] public partial record MyPositiveDecimal;

    [NonEmptyString] public partial record MyNonEmptyString;

    [MinLength(5)] public partial record MyMinLength;

    [MaxLength(25)] public partial record MyMaxLength;

    [MinMaxLength(10, 30)] public partial record MinMaxLength;

    [Regex(@"\d\w")] public partial record MyRegex;
}
