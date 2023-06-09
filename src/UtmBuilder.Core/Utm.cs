using UtmBuilder.Core.Exceptions;
using UtmBuilder.Core.Extensions;
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core;

/// <summary>
/// Represent a Urchin Tracking Module - UTM
/// </summary>
public sealed class Utm
{
    /// <summary>
    /// Create a new UTM
    /// </summary>
    /// <param name="url">URL (Website Link)</param>
    /// <param name="campaign">Campaign Details</param>
    public Utm(Url url, Campaign campaign)
    {
        Url = url;
        Campaign = campaign;
    }

    /// <summary>
    /// Campaign Details
    /// </summary>
    public Campaign Campaign { get; }

    /// <summary>
    /// URL (Website Link)
    /// </summary>
    public Url Url { get; }

    /// <summary>
    /// Implicitly converts a url string to urchin traffic monitor (UTM).
    /// </summary>
    /// <param name="link">URL address string.</param>
    /// <returns>Returns a UTM object.</returns>
    /// <exception cref="InvalidUrlException">Throw an invalid url exception when the link don't have segments.</exception
    public static implicit operator Utm(string link)
    {
        Url url = link;
        var queryStrings = url.GetQueryStrings();

        _ = queryStrings.TryGetValue("utm_medium", out var medium);
        _ = queryStrings.TryGetValue("utm_campaign", out var name);
        _ = queryStrings.TryGetValue("utm_source", out var source);
        _ = queryStrings.TryGetValue("utm_id", out var id);
        _ = queryStrings.TryGetValue("utm_content", out var content);
        _ = queryStrings.TryGetValue("utm_term", out var term);

        return string.IsNullOrEmpty(medium) ||
            string.IsNullOrEmpty(name) ||
            string.IsNullOrEmpty(source)
            ? throw new InvalidUrlException("Undeclared UTM required parameters.")
            : new Utm(
            new Url(url.GetBaseAddress()),
            new Campaign(source, medium, name, id, term, content)
        );
    }

    /// <summary>
    /// Converts an <see cref="Utm"/> object to a string
    /// </summary>
    /// <param name="utm">The UTM object</param>
    /// <returns>Returns a string converted</returns>
    public static implicit operator string(Utm utm)
        => utm.ToString();

    /// <summary>
    /// Returns a string to represents an <see cref="Utm"/> object
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        var segments = new List<string>();
        segments.AddIfNotNull("utm_source", Campaign.Source);
        segments.AddIfNotNull("utm_medium", Campaign.Medium);
        segments.AddIfNotNull("utm_campaign", Campaign.Name);
        segments.AddIfNotNull("utm_id", Campaign.Id);
        segments.AddIfNotNull("utm_term", Campaign.Term);
        segments.AddIfNotNull("utm_content", Campaign.Content);

        return $"{Url}?{string.Join('&', segments)}";
    }
}
