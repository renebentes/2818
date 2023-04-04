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
    public void Constructor_ShouldReturnExceptionWhenInvalidUrl()
    {
        foreach (var address in _invalidUrls)
        {
            Assert.ThrowsException<InvalidUrlException>(() => new Url(address));
        }
    }

    [TestMethod]
    public void ToString_ShouldReturnAddressProperty()
    {
        foreach (var address in _validUrls)
        {
            var url = new Url(address);
            Assert.AreEqual(url.Address, url.ToString());
        }
    }

    [TestMethod]
    public void ImplicitOperatorString_ShouldReturnAddressProperty()
    {
        foreach (var address in _validUrls)
        {
            var url = new Url(address);
            string actual = url;
            Assert.AreEqual(url.Address, actual);
        }
    }

    [TestMethod]
    public void ImplicitOperatorUrl_ShouldConvertToUrlObject()
    {
        foreach (var address in _validUrls)
        {
            Url url = address;
            Assert.IsInstanceOfType(url, typeof(Url));
        }
    }
}
