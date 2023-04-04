using UtmBuilder.Core.Exceptions;
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Extensions;

/// <summary>
/// <see cref="Url"/> extensions
/// </summary>
public static class UrlExtensions
{
    /// <summary>
    /// Gets the value for a query string <paramref name="key"/> in the <paramref name="url"/> address.
    /// </summary>
    /// <param name="url">The Unified Resource Locator (URL)</param>
    /// <param name="key">The query string key</param>
    /// <returns>A query string value</returns>
    /// <exception cref="InvalidCampaignException"></exception>
    public static string? GetQueryString(this Url url, string key)
    {
        ArgumentNullException.ThrowIfNull(nameof(key));

        var segments = url.Address.Split('?');

        if (segments.Length == 1)
        {
            throw new InvalidUrlException("No segments were provided");
        }

        var pairs = segments[1].Split('&');
        return Array.Find(pairs, pair => pair.StartsWith(key))?.Split('=')[1];
    }

    /// <summary>
    /// Gets the query strings from <paramref name="url"/> address
    /// </summary>
    /// <param name="url">The <see cref="Url"/> object</param>
    /// <param name="address">The address result</param>
    /// <returns>Returns a <see cref="Dictionary{TKey,TValue}"/> that represents query strings key-value pair</returns>
    /// <exception cref="InvalidUrlException"></exception>
    public static Dictionary<string, string> GetQueryStrings(this Url url, out string address)
    {
        var segments = url.Address.Split('?');
        address = segments[0];

        if (segments.Length == 1)
        {
            throw new InvalidUrlException("No segments were provided");
        }

        var pairs = segments[1].Split('&');
        return pairs.ToDictionary(pair => pair.Split('=')[0], pair => pair.Split('=')[1]);
    }

    /// <summary>
    /// Removes all query strings from <see cref="Url"/> address
    /// </summary>
    /// <param name="url">The URL address</param>
    /// <returns>A website address without query strings</returns>
    public static string RemoveQueryStrings(this Url url)
        => url.Address.Split('?')[0];
}
