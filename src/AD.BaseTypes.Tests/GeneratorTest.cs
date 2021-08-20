using AD.BaseTypes.Converters;
using AD.BaseTypes.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace AD.BaseTypes.Tests
{
    [TestClass]
    public class GeneratorTest
    {
        static T GetAttribute<T>() where T : Attribute
        {
            var attributes = typeof(ZeroToTen).GetCustomAttributes(typeof(T), false);
            Assert.AreEqual(1, attributes.Length);
            return attributes[0] as T ?? throw new AssertFailedException($"attribute {typeof(T)} not found");
        }

        [TestMethod]
        public void TypeConverterAttribute() => Assert.AreEqual(typeof(BaseTypeTypeConverter<ZeroToTen, int>).AssemblyQualifiedName, GetAttribute<TypeConverterAttribute>().ConverterTypeName);

        [TestMethod]
        public void JsonConverterAttribute() => Assert.AreEqual(typeof(BaseTypeJsonConverter<ZeroToTen, int>), GetAttribute<JsonConverterAttribute>().ConverterType);
    }
}
