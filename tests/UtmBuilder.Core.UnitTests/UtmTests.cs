namespace UtmBuilder.Core.UnitTests;

[TestClass]
public class UtmTests
{
    private const string Expected =
        "https://balta.io/?utm_source=src&utm_medium=med&utm_campaign=camp&utm_id=id&utm_term=term&utm_content=cont";

    private readonly Url _url = new Url("https://balta.io");
    private readonly Campaign _campaign = new Campaign("src", "med", "camp", "id", "term", "cont");

    [TestMethod]
    public void ToString_ShouldReturnUrl()
    {
        var utm = new Utm(_url, _campaign);
        Assert.AreEqual(Expected, utm.ToString());
    }

    [TestMethod]
    public void ImplicitOperatorString_ShouldReturnUrl()
    {
        var utm = new Utm(_url, _campaign);
        string actual = utm;
        Assert.AreEqual(Expected, actual);
    }

    [TestMethod]
    public void ImplicitOperatorUtm_ShouldReturnUtmFromUrl()
    {
        Utm utm = Expected;
        Assert.AreEqual("https://balta.io/", utm.Url.Address);
        Assert.AreEqual("src", utm.Campaign.Source);
        Assert.AreEqual("med", utm.Campaign.Medium);
        Assert.AreEqual("camp", utm.Campaign.Name);
        Assert.AreEqual("id", utm.Campaign.Id);
        Assert.AreEqual("term", utm.Campaign.Term);
        Assert.AreEqual("cont", utm.Campaign.Content);
    }
}
