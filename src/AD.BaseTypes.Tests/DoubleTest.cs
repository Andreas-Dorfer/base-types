using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AD.BaseTypes.Tests
{
    [Double] public partial record MyDouble;

    [TestClass]
    public class DoubleTest : BaseTypeTest<MyDouble, double>
    {
        protected override MyDouble New(double value) => new(value);

        protected override bool JsonFilter(double value) => double.IsFinite(value);
    }
}
