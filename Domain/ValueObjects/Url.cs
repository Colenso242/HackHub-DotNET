namespace HackHub_DotNET.Domain.ValueObjects;

public sealed record Url : IValueObject
{
    public string Value { get; }

    //todo validate
    public Url(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("URL is required.", nameof(value));
        if (!Uri.IsWellFormedUriString(value, UriKind.Absolute))
            throw new ArgumentException($"'{value}' is not a valid absolute URL.", nameof(value));
        Value = value;
    }

    public override string ToString() => Value;

    public static implicit operator string(Url url) => url.Value;
}
