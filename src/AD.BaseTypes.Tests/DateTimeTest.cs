using AD.BaseTypes.Arbitraries;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.BaseTypes.Tests
{
    [DateTime] public partial record MyDateTime;

    [TestClass]
    public class DateTimeTest : BaseTypeTest<MyDateTime, DateTime>
    {
        protected override Arbitrary<MyDateTime> Arbitrary => new DateTimeArbitrary<MyDateTime>();
    }
}
