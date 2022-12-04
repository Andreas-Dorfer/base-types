namespace TestApp.UserAggregate;

[Int] public readonly partial record struct UserId;
[DateTime] public partial record BirthDate;

[NonEmptyString, MinMaxLengthString(MinLength, MaxLength)]
public partial record FirstName
{
    public const int MinLength = 3, MaxLength = 50;
}

[NonEmptyString, MinMaxLengthString(MinLength, MaxLength)]
public partial record LastName
{
    public const int MinLength = 3, MaxLength = 50;
}