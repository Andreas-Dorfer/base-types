namespace AD.BaseTypes.Tests;

[DateTime] public partial record MyDateTime;

[TestClass]
public class DateTimeTest : BaseTypeTest<MyDateTime, DateTime>
{
    protected override DateTimeArbitrary<MyDateTime> Arbitrary => new();
}

[DateTime] public readonly partial record struct MyDateTimeStruct;

[TestClass]
public class DateTimeStructTest : BaseTypeTest<MyDateTimeStruct, DateTime>
{
    protected override DateTimeArbitrary<MyDateTimeStruct> Arbitrary => new();
}