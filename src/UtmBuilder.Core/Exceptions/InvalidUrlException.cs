namespace UtmBuilder.Core.Exceptions;

public class InvalidUrlException : Exception
{
    public InvalidUrlException(string? message = "Invalid URL")
        : base(message)
    {
    }
}
