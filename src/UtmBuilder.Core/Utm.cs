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
