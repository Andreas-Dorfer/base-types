using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

namespace AD.BaseTypes.Tests
{
    [TestClass]
    public class JsonTest
    {
        [TestMethod, ExpectedException(typeof(JsonException))]
        public void InvalidDeserialize() => JsonSerializer.Deserialize<ZeroToTen>(JsonSerializer.Serialize(ZeroToTen.Max + 1));
    }
}
