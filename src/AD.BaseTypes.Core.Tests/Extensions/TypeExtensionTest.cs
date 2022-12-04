using AD.BaseTypes.Extensions;

namespace AD.BaseTypes.Core.Tests.Extensions;

public record WithoutBaseType { }
public record WithBaseType : IBaseType<WithBaseType, string>
{
    public string Value => throw new NotImplementedException();

    public static WithBaseType Create(string value)
    {
        throw new NotImplementedException();
    }
}

[TestClass]
public class TypeExtensionsTest
{
    [TestMethod]
    [DataRow(typeof(WithBaseType))]
    public void ImplementsIBaseType_Returns_True(Type type) => Assert.IsTrue(type.ImplementsIBaseType());

    [TestMethod]
    [DataRow(typeof(WithoutBaseType))]
    public void ImplementsIBaseType_Returns_False(Type type) => Assert.IsFalse(type.ImplementsIBaseType());
}