namespace UtmBuilder.Core.Extensions;

/// <summary>
/// <see cref="string"/> Extensions
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Gets the base address for a website link. 
    /// </summary>
    /// <example>For example:
    /// <code>
    ///     string link = "http://test.com/article.html?id=10"
    ///     Console.WriteLine(link.GetBaseAddress()
    /// </code>
    /// Outputs only <c>http://test.com/</c>
    /// </example>
    /// <param name="link">An website link</param>
    /// <returns>The base address</returns>
    public static string GetBaseAddress(this string link)
        => RegexPatterns.UrlRegex().Replace(link, "${1}://${2}/");
}
