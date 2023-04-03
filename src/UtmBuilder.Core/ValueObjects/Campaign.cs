using UtmBuilder.Core.Exceptions;

namespace UtmBuilder.Core.ValueObjects;

public sealed class Campaign : ValueObject
{
    /// <summary>
    /// Generate a new campaign for a URL
    /// </summary>
    /// <param name="source">The referrer (e.g. google, newsletter)</param>
    /// <param name="medium">Marketing medium (e.g. cpc, banner, email)</param>
    /// <param name="name">Product, promo code, or slogan (e.g. spring_sale) One of campaign name or campaign id are required.</param>
    /// <param name="id">The ads campaign id.</param>
    /// <param name="term">Identify the paid keywords</param>
    /// <param name="content">Use to differentiate ads</param>
    public Campaign(
        string source,
        string medium,
        string name,
        string? id = null,
        string? term = null,
        string? content = null)
    {
        Content = content;
        Id = id;
        Medium = medium;
        Name = name;
        Source = source;
        Term = term;

        InvalidCampaignException.ThrowIfNullOrEmpty(Source, "Source is invalid");
        InvalidCampaignException.ThrowIfNullOrEmpty(Medium, "Medium is invalid");
        InvalidCampaignException.ThrowIfNullOrEmpty(Name, "Name is invalid");
    }

    /// <summary>
    /// Use to differentiate ads
    /// </summary>
    public string? Content { get; }

    /// <summary>
    /// The ads campaign id.
    /// </summary>
    public string? Id { get; }

    /// <summary>
    /// Marketing medium (e.g. cpc, banner, email)
    /// </summary>
    public string Medium { get; }

    /// <summary>
    /// Product, promo code, or slogan (e.g. spring_sale) One of campaign name or campaign id are required.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The referrer (e.g. google, newsletter)
    /// </summary>
    public string Source { get; }

    /// <summary>
    /// Identify the paid keywords
    /// </summary>
    public string? Term { get; }
}
