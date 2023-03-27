using System.Text.RegularExpressions;
using UtmBuilder.Core.Exceptions;

namespace UtmBuilder.Core.ValueObjects;

public sealed class Url : ValueObject
{
    private const string UrlRegexPattern =
        @"^(http|https):(\\/\\/www\\.|\\/\\/www\\.|\\/\\/|\\/\\/)[a-z0-9]+([\\-\\.]{1}[a-z0-9]+)*\\.[a-z]{2,5}(:[0-9]{1,5})?(\\/.*)?$|(http|https):(\\/\\/localhost:\\d*|\\/\\/127\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))(:[0-9]{1,5})?(\\/.*)?$";
    
    /// <summary>
    /// Create a new URL
    /// </summary>
    /// <param name="address">Address of URL (Website link)</param>
    public Url(string address)
    {
        Address = address;

        if (Regex.IsMatch(Address, UrlRegexPattern))
        {
            throw new InvalidUrlException();
        }
    }

    /// <summary>
    /// Address of URL (Website link)
    /// </summary>
    public string Address { get; }
}
