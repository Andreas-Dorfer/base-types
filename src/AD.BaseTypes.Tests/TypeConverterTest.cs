using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;

namespace AD.BaseTypes.Tests
{
    [TestClass]
    public class TypeConverterTest
    {
        readonly TypeConverter converter = TypeDescriptor.GetConverter(typeof(ZeroToTen));

        [TestMethod, ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void InvalidConvertFrom() => converter.ConvertFrom(ZeroToTen.Max + 1);

        [TestMethod, ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void InvalidConvertFromString() => converter.ConvertFromString((ZeroToTen.Max + 1).ToString());
    }
}
