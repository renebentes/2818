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
    /// <returns>Returns a <see cref="Dictionary{TKey,TValue}"/> that represents query strings key-value pair</returns>
    /// <exception cref="InvalidUrlException"></exception>
    public static Dictionary<string, string> GetQueryStrings(this Url url)
    {
        var segments = url.Address.Split('?');

        if (segments.Length == 1 || string.IsNullOrEmpty(segments[1]))
        {
            throw new InvalidUrlException("No segments were provided");
        }

        var pairs = segments[1].Split('&');
        return pairs.ToDictionary(pair => pair.Split('=')[0], pair => pair.Split('=')[1]);
    }

    /// <summary>
    /// Gets the base address (protocol and domain) for a <see cref="Url"/> objects.
    /// </summary>
    /// <example>For example:
    /// <code>
    ///     Url url = new Url("http://test.com/article.html?id=10");
    ///     Console.WriteLine(url.GetBaseAddress();
    /// </code>
    /// Outputs only <c>http://test.com/</c>
    /// </example>
    /// <param name="url">An Url object</param>
    /// <returns>The base address</returns>
    public static string GetBaseAddress(this Url url)
        => RegexPatterns.UrlRegex().Replace(url.Address, "${1}://${2}/");
}
