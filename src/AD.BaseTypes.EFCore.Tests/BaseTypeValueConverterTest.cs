namespace AD.BaseTypes.EFCore.Tests;

[String] public partial record MyString;

[TestClass]
public class BaseTypeValueConverterTest
{
    const string expectedString = "MyValue";
    readonly BaseTypeValueConverter<MyString, string> converter = new();
    readonly MyString expected = MyString.Create(expectedString);

    [TestMethod]
    public void ConvertFromProvider() =>
        Assert.AreEqual(expected, converter.ConvertFromProvider(expectedString));

    [TestMethod]
    public void ConvertToProvider() =>
        Assert.AreEqual(expectedString, converter.ConvertToProvider(expected));
}