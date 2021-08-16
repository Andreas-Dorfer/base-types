using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AD.BaseTypes.Tests
{
    [Decimal] public partial record MyDecimal;

    [TestClass]
    public class DecimalTest : BaseTypeTest<MyDecimal, decimal>
    {
        protected override MyDecimal New(decimal value) => new(value);
    }
}
