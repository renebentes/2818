using UtmBuilder.Core.Exceptions;

namespace UtmBuilder.Core.ValueObjects;

public sealed class Url : ValueObject
{
    /// <summary>
    /// Create a new URL
    /// </summary>
    /// <param name="address">Address of URL (Website link)</param>
    public Url(string address)
    {
        Address = address;

        InvalidUrlException.ThrowIfInvalid(Address);
    }

    /// <summary>
    /// Address of URL (Website link)
    /// </summary>
    public string Address { get; }

    /// <summary>
    /// Converts a website <paramref name="address"/> to an <see cref="Url"/> object 
    /// </summary>
    /// <param name="address">The website address</param>
    /// <returns>Returns an <see cref="Url"/> object</returns>
    public static implicit operator Url(string address)
        => new(address);

    /// <summary>
    /// Converts an <paramref name="url"/> object to a website address
    /// </summary>
    /// <param name="url">The Url object</param>
    /// <returns>Returns a website address</returns>
    public static implicit operator string(Url url)
        => url.ToString();

    /// <summary>
    /// Returns a website address that represents an <see cref="Url"/> object
    /// </summary>
    /// <returns>Returns the website <see cref="Address"/></returns>
    public override string ToString()
        => Address;
}
