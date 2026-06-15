namespace HackHub_DotNET.Domain.ValueObjects;

public sealed record Grade : IValueObject
{
    public int Score { get; }
    public string? Comment { get; }

    public Grade(int score, string? comment = null)
    {
        if (score is < 0 or > 10)
            throw new ArgumentOutOfRangeException(nameof(score), "Score must be between 0 and 10.");
        if (comment is { Length: > 1000 })
            throw new ArgumentException("Grade comment must be at most 1000 characters.", nameof(comment));

        Score = score;
        Comment = comment;
    }
}
