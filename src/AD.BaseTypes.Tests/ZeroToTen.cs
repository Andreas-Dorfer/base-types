namespace AD.BaseTypes.Tests
{
    //type for multiple tests

    [IntRange(Min, Max)]
    public partial record ZeroToTen
    {
        public const int Min = 0, Max = 10;
    }
}
