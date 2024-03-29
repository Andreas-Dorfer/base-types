﻿namespace AD.BaseTypes.Tests;

[MinInt(Min)]
public partial record MyMinInt
{
    public const int Min = -100;
}

[TestClass]
public class MinIntTest : BaseTypeTest<MyMinInt, int>
{
    protected override MinIntArbitrary<MyMinInt> Arbitrary => new(MyMinInt.Min);

    [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TooSmall() => new MyMinInt(MyMinInt.Min - 1);
}
