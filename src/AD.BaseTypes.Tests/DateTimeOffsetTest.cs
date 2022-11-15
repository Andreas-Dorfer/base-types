namespace AD.BaseTypes.Tests;

[DateTimeOffset] public partial record MyDateTimeOffset;

[TestClass]
public class DateTimeOffsetTest : BaseTypeTest<MyDateTimeOffset, DateTimeOffset>
{
    protected override DateTimeOffsetArbitrary<MyDateTimeOffset> Arbitrary => new();
}

[DateTimeOffset] public partial record struct MyDateTimeOffsetStruct;

[TestClass]
public class DateTimeOffsetStructTest : BaseTypeTest<MyDateTimeOffsetStruct, DateTimeOffset>
{
    protected override DateTimeOffsetArbitrary<MyDateTimeOffsetStruct> Arbitrary => new();
}