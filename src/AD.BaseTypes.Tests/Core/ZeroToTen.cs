namespace AD.BaseTypes.Tests.Core
{
    //type for multiple tests

    [MinMaxInt(Min, Max), BaseType(Cast.Implicit)]
    public partial record ZeroToTen
    {
        public const int Min = 0, Max = 10;
    }
}
