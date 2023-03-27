namespace UtmBuilder.Core.ValueObjects;

public sealed class Campaign : ValueObject
{
    public Campaign(
        string source,
        string medium,
        string name,
        string? id = null,
        string? term = null,
        string? content = null)
    {
        Content = content;
        Id = id;
        Medium = medium;
        Name = name;
        Source = source;
        Term = term;
    }

    public string? Content { get; }

    public string? Id { get; }

    public string Medium { get; }

    public string Name { get; }

    public string Source { get; }

    public string? Term { get; }
}
