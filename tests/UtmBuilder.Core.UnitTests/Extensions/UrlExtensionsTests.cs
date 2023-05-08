using UtmBuilder.Core.Extensions;

namespace UtmBuilder.Core.UnitTests.Extensions;

[TestClass]
public class UrlExtensionsTests
{
    private readonly string[] _urlsWithQueryStrings =
    {
        "https://balta.io/?utm_source=source&utm_medium=medium&utm_campaign=campaign", "https://balta.io?id=id"
    };

    private readonly string[] _urlsWithoutQueryStrings =
    {
        "https://balta.io", "https://balta.io?", "https://balta.io/cursos"
    };

    [TestMethod]
    public void GetQueryStrings_ShouldReturnDictionaryWithElements()
    {
        foreach (var address in _urlsWithQueryStrings)
        {
            var url = new Url(address);
            var actual = url.GetQueryStrings();
            Assert.IsTrue(actual.Count > 0);
        }
    }

    [TestMethod]
    public void GetQueryStrings_ShouldReturnInvalidUrlExceptionWhenNoQueryStringsProvided()
    {
        foreach (var address in _urlsWithoutQueryStrings)
        {
            var url = new Url(address);
            _ = Assert.ThrowsException<InvalidUrlException>(url.GetQueryStrings);
        }
    }

    [TestMethod]
    [DataRow("https://balta.io", "https://balta.io/")]
    [DataRow("https://balta.io?id=id", "https://balta.io/")]
    [DataRow("https://balta.io/?id=id", "https://balta.io/")]
    [DataRow("https://balta.io/12564", "https://balta.io/")]
    [DataRow("https://balta.io/cursos/dominios-ricos", "https://balta.io/")]
    [DataRow("https://balta.io/artigos.html?id=10", "https://balta.io/")]
    public void GetBaseAddress_ShouldReturnBaseAddressLink(string link, string expected)
    {
        var url = new Url(link);
        var actual = url.GetBaseAddress();
        Assert.AreEqual(expected, actual);
    }
}
