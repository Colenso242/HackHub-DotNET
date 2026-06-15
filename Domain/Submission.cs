namespace HackHub_DotNET.Domain;

public class Submission : BaseEntity
{
    public string RepositoryUrl { get; private set; }
    public Hackathon Hackathon { get; private set; }
    public Team Team { get; private set; }
    public User LastEditedBy { get; private set; }

    // Optional: a submission is not scored/commented until it is graded.
    public int? Score { get; private set; }
    public string? GradeComment { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public Submission(string repositoryUrl, Hackathon hackathon, Team team, User lastEditedBy)
    {
        RepositoryUrl = Require(repositoryUrl, nameof(repositoryUrl));
        Hackathon = hackathon ?? throw new ArgumentNullException(nameof(hackathon));
        Team = team ?? throw new ArgumentNullException(nameof(team));
        LastEditedBy = lastEditedBy ?? throw new ArgumentNullException(nameof(lastEditedBy));
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateRepositoryUrl(string repositoryUrl, User editedBy)
    {
        RepositoryUrl = Require(repositoryUrl, nameof(repositoryUrl));
        Touch(editedBy);
    }

    public void Grade(int score, string? comment, User gradedBy)
    {
        if (score is < 0 or > 10)
            throw new ArgumentOutOfRangeException(nameof(score), "Score must be between 0 and 10.");
        if (comment is { Length: > 1000 })
            throw new ArgumentException("Grade comment must be at most 1000 characters.", nameof(comment));

        Score = score;
        GradeComment = comment;
        Touch(gradedBy);
    }

    private void Touch(User editedBy)
    {
        LastEditedBy = editedBy ?? throw new ArgumentNullException(nameof(editedBy));
        UpdatedAt = DateTime.UtcNow;
    }

    private static string Require(string value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{paramName} is required.", paramName);
        return value;
    }
}