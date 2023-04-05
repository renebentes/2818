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

    private const string ExpectedAddress = "https://balta.io/";

    [TestMethod]
    public void GetQueryStrings_ShouldReturnBaseAddress()
    {
        foreach (var address in _urlsWithQueryStrings)
        {
            var url = new Url(address);
            url.GetQueryStrings(out string actual);
            Assert.AreEqual(ExpectedAddress, actual);
        }
    }

    [TestMethod]
    public void GetQueryStrings_ShouldReturnDictionaryWithElements()
    {
        foreach (var address in _urlsWithQueryStrings)
        {
            var url = new Url(address);
            var actual = url.GetQueryStrings(out string _);
            Assert.IsTrue(actual.Count > 0);
        }
    }

    [TestMethod]
    public void GetQueryStrings_ShouldReturnInvalidUrlExceptionWhenNoQueryStringsProvided()
    {
        foreach (var address in _urlsWithoutQueryStrings)
        {
            var url = new Url(address);
            Assert.ThrowsException<InvalidUrlException>(() => url.GetQueryStrings(out string _));
        }
    }
}
