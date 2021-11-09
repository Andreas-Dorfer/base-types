using System.ComponentModel;

namespace AD.BaseTypes.Tests.Core;

[TestClass]
public class TypeConverterTest
{
    readonly TypeConverter converter = TypeDescriptor.GetConverter(typeof(ZeroToTen));

    [TestMethod, ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
    public void InvalidConvertFrom() => converter.ConvertFrom(ZeroToTen.Max + 1);

    [TestMethod, ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
    public void InvalidConvertFromString() => converter.ConvertFromString((ZeroToTen.Max + 1).ToString());

    [TestMethod]
    public void NotSupportedCanConvertFrom() => Assert.IsFalse(converter.CanConvertFrom(typeof(double)));

    [TestMethod, ExpectedException(typeof(NotSupportedException))]
    public void NotSupportedConvertFrom() => converter.ConvertFrom(5.0);

    [TestMethod]
    public void NotSupportedCanConvertTo() => Assert.IsFalse(converter.CanConvertTo(typeof(DateTime)));

    [TestMethod, ExpectedException(typeof(NotSupportedException))]
    public void NotSupportedConvertTo() => converter.ConvertTo(new ZeroToTen(ZeroToTen.Max / 2), typeof(DateTime));
}
