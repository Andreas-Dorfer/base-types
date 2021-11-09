using System.Text.Json;

namespace AD.BaseTypes.Tests.Core
{
    [TestClass]
    public class JsonTest
    {
        [TestMethod, ExpectedException(typeof(JsonException))]
        public void InvalidDeserialize() => JsonSerializer.Deserialize<ZeroToTen>(JsonSerializer.Serialize(ZeroToTen.Max + 1));
    }
}
