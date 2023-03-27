namespace UtmBuilder.Core.ValueObjects;

public sealed class Url : ValueObject
{
    public Url(string address)
    {
        Address = address;
    }

    public string Address { get; }
}
