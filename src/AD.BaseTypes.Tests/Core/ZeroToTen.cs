namespace AD.BaseTypes.Tests.Core
{
    //type for multiple tests

    [MinMaxInt(Min, Max)]
    public partial record ZeroToTen
    {
        public const int Min = 0, Max = 10;
    }
}
