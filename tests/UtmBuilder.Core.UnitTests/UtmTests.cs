namespace UtmBuilder.Core.UnitTests;

[TestClass]
public class UtmTests
{
    [TestMethod]
    public void ToString_ShouldReturnUrlFromUtm()
    {
        const string expected =
            "https://balta.io/?utm_source=src&utm_medium=med&utm_campaign=camp&utm_id=id&utm_term=term&utm_content=cont";
        var url = new Url("https://balta.io");
        var campaign = new Campaign("src", "med", "camp", "id", "term", "cont");
        var utm = new Utm(url, campaign);

        Assert.AreEqual(expected, utm.ToString());
    }
}
