using System.Text.RegularExpressions;

namespace UtmBuilder.Core;

public static partial class RegexPatterns
{
    [GeneratedRegex(
        @"^(https?):\/\/((www.)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}|localhost|(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?))(:[0-9]{1,5})?((\/|\?).*)?$")]
    public static partial Regex UrlRegex();
}
