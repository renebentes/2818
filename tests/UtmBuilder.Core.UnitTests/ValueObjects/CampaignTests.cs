namespace UtmBuilder.Core.UnitTests.ValueObjects;

[TestClass]
public class CampaignTests
{
    [TestMethod]
    [DataRow(null, null, null)]
    [DataRow("", "", "")]
    [DataRow("", "medium", "name")]
    [DataRow("source", "", "name")]
    [DataRow("source", "medium", "")]
    public void Constructor_ShouldReturnExceptionWhenInvalidCampaign(string source, string medium, string name)
        => Assert.ThrowsException<InvalidCampaignException>(() => new Campaign(source, medium, name));

    [TestMethod]
    [DataRow("source", "medium", "name", "id", "term", "content")]
    [DataRow("source", "medium", "name", "id", "term", "")]
    [DataRow("source", "medium", "name", "id", "", "content")]
    [DataRow("source", "medium", "name", "id", "", "")]
    [DataRow("source", "medium", "name", "", "term", "content")]
    [DataRow("source", "medium", "name", "", "term", "")]
    [DataRow("source", "medium", "name", "", "", "content")]
    [DataRow("source", "medium", "name", "", "", "")]
    public void Constructor_ShouldNotReturnExceptionWhenValidCampaign(string source,
        string medium,
        string name,
        string id,
        string term,
        string content)
        => _ = new Campaign(source, medium, name, id, term, content);
}
