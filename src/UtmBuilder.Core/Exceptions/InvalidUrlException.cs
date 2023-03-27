using System.Text.RegularExpressions;

namespace UtmBuilder.Core.Exceptions;

/// <summary>
/// The exception that is thrown when an URL is not valid.
/// </summary>
public partial class InvalidUrlException : Exception
{
    /// <summary>
    /// The default error message
    /// </summary>
    private const string DefaultErrorMessage = "Invalid URL";

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidUrlException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public InvalidUrlException(string message = DefaultErrorMessage)
        : base(message)
    { }

    /// <summary>
    /// Throws an <see cref="InvalidUrlException"/> if <paramref name="address"/> is null, empty or an invalid
    /// URL.
    /// </summary>
    /// <param name="address">The string to validate</param>
    /// <param name="message">The message that describes the error.</param>
    /// <exception cref="InvalidUrlException"></exception>
    public static void ThrowIfInvalid(string address, string message = DefaultErrorMessage)
    {
        if (string.IsNullOrEmpty(address))
        {
            throw new InvalidUrlException(message);
        }

        if (!UrlRegex().IsMatch(address))
        {
            throw new InvalidUrlException(message);
        }
    }

    [GeneratedRegex("^(http|https):(\\/\\/www\\.|\\/\\/www\\.|\\/\\/|\\/\\/)[a-z0-9]+([\\-\\.]{1}[a-z0-9]+)*\\.[a-z]{2,5}(:[0-9]{1,5})?(\\/.*)?$|(http|https):(\\/\\/localhost:\\d*|\\/\\/127\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))(:[0-9]{1,5})?(\\/.*)?$")]
    private static partial Regex UrlRegex();
}
