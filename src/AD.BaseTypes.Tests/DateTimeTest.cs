using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AD.BaseTypes.Tests
{
    [DateTime] public partial record MyDateTime;

    [TestClass]
    public class DateTimeTest : BaseTypeTest<MyDateTime, DateTime>
    {
        protected override MyDateTime New(DateTime value) => new(value);
    }
}