using UtmBuilder.Core.Exceptions;
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Extensions;

/// <summary>
/// <see cref="Url"/> extensions
/// </summary>
public static class UrlExtensions
{
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
        address = segments[0].EndsWith("/") ? segments[0] : $"{segments[0]}/";

        if (segments.Length == 1 || string.IsNullOrEmpty(segments[1]))
        {
            throw new InvalidUrlException("No segments were provided");
        }

        var pairs = segments[1].Split('&');
        return pairs.ToDictionary(pair => pair.Split('=')[0], pair => pair.Split('=')[1]);
    }
}
