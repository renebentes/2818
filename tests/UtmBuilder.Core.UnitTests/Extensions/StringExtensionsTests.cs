using UtmBuilder.Core.Extensions;

namespace UtmBuilder.Core.UnitTests.Extensions;

[TestClass]
public class StringExtensionsTests
{
    [TestMethod]
    [DataRow("https://balta.io", "https://balta.io/")]
    [DataRow("https://balta.io?id=id", "https://balta.io/")]
    [DataRow("https://balta.io/?id=id", "https://balta.io/")]
    [DataRow("https://balta.io/12564", "https://balta.io/")]
    [DataRow("https://balta.io/cursos/dominios-ricos", "https://balta.io/")]
    [DataRow("https://balta.io/artigos.html?id=10", "https://balta.io/")]
    public void GetBaseAddress_ShouldReturnBaseAddressLink(string link, string expected)
        => Assert.AreEqual(expected, link.GetBaseAddress());
}
