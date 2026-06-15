using HackHub_DotNET.Domain.ValueObjects;

namespace HackHub_DotNET.Domain;

public class Submission : BaseEntity, IAggregateRoot
{
    public Url RepositoryUrl { get; private set; }
    public Guid HackathonId { get; private set; }
    public Guid TeamId { get; private set; }
    public Guid LastEditedById { get; private set; }

    // Optional: a submission is not graded until a judge scores it.
    public Grade? Grade { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public Submission(Url repositoryUrl, Guid hackathonId, Guid teamId, Guid lastEditedById)
    {
        RepositoryUrl = repositoryUrl ?? throw new ArgumentNullException(nameof(repositoryUrl));
        HackathonId = RequireId(hackathonId, nameof(hackathonId));
        TeamId = RequireId(teamId, nameof(teamId));
        LastEditedById = RequireId(lastEditedById, nameof(lastEditedById));
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateRepositoryUrl(Url repositoryUrl, Guid editedById)
    {
        RepositoryUrl = repositoryUrl ?? throw new ArgumentNullException(nameof(repositoryUrl));
        Touch(editedById);
    }

    public void AssignGrade(Grade grade, Guid gradedById)
    {
        Grade = grade ?? throw new ArgumentNullException(nameof(grade));
        Touch(gradedById);
    }

    private void Touch(Guid editedById)
    {
        LastEditedById = RequireId(editedById, nameof(editedById));
        UpdatedAt = DateTime.UtcNow;
    }
}
