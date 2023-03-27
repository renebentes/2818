namespace UtmBuilder.Core.Exceptions;

/// <summary>
/// The exception that is thrown when a Campaign is not valid.
/// </summary>
public sealed class InvalidCampaignException : Exception
{
    /// <summary>
    /// The default error message
    /// </summary>
    private const string DefaultErrorMessage = "Invalid Campaign parameters";

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidCampaignException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public InvalidCampaignException(
        string message = DefaultErrorMessage) : base(message)
    { }

    /// <summary>
    /// Throws an <see cref="InvalidCampaignException"/> if <paramref name="item"/> is null or empty.
    /// </summary>
    /// <param name="item">The campaign item to validate</param>
    /// <param name="message">The message that describes the error.</param>
    public static void ThrowIfNullOrEmpty(string item, string message = DefaultErrorMessage)
    {
        if (string.IsNullOrEmpty(item))
        {
            throw new InvalidCampaignException(message);
        }
    }
}
