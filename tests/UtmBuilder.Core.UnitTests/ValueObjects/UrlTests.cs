namespace UtmBuilder.Core.UnitTests.ValueObjects;

[TestClass]
public class UrlTests
{
    private readonly string[] _invalidUrls =
    {
        "", "localhost", "10.0.0.1", "127.0.0.1", "https://256.0.0.1", "http://1.256.0.1", "http://1.0.256.1",
        "http://1.0.0.256"
    };

    private readonly string[] _validUrls =
    {
        "https://balta.io", "http://localhost", "http://127.0.0.1", "https://192.168.0.1",
        "https://meudominio.com/?id=555"
    };

    [TestMethod]
    public void ShouldReturnExceptionWhenInvalidUrl()
    {
        foreach (var address in _invalidUrls)
        {
            Assert.ThrowsException<InvalidUrlException>(() => new Url(address));
        }
    }

    [TestMethod]
    public void ShouldReturnAddressWhenValidUrl()
    {
        foreach (var address in _validUrls)
        {
            var url = new Url(address);
            Assert.AreEqual(address, url.ToString());
        }
    }
}
