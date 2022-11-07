namespace TestApp;

[Int] public partial record MyInt;

[Double] public partial record MyDouble;

[Decimal] public partial record MyDecimal;

[String] public partial record MyString;

[Guid] public partial record MyGuid;

[DateTime] public partial record MyDateTime;

[MinInt(-100)] public partial record MyMinInt;

[MaxInt(100)] public partial record MyMaxInt;

[MinMaxInt(-10, 10)] public partial record MyMinMaxInt;

[PositiveDecimal] public partial record MyPositiveDecimal;

[NonEmptyGuid] public partial record MyNonEmptyGuid;

[NonEmptyString] public partial record MyNonEmptyString;

[MinLengthString(5)] public partial record MyMinLengthString;

[MaxLengthString(25)] public partial record MyMaxLengthString;

[MinMaxLengthString(10, 30)] public partial record MinMaxLengthString;

[RegexString(@"\d\w")] public partial record MyRegexString;
