namespace UtmBuilder.Core.Extensions;

/// <summary>
/// <see cref="List{T}"/> Extensions
/// </summary>
public static class ListExtensions
{
    /// <summary>
    /// Adds a non-null or empty <paramref name="value"/> to a <paramref name="key"/>-value <paramref name="list"/>
    /// </summary>
    /// <param name="list">The string list</param>
    /// <param name="key">The key to add</param>
    /// <param name="value">The value to add</param>
    public static void AddIfNotNull(this List<string> list, string key, string? value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            list.Add($"{key}={value}");
        }
    }

}
