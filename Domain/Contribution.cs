using HackHub_DotNET.Domain.Enums;

namespace HackHub_DotNET.Domain;

public class Contribution : BaseEntity, IAggregateRoot
{
    public ContributionType Type { get; private set; }
    public ContributionStatus Status { get; private set; }
    public Guid SenderId { get; private set; }
    public Guid ReceiverId { get; private set; }

    // Optional: a contribution is not necessarily scoped to a hackathon or a team.
    public Guid? HackathonId { get; private set; }
    public Guid? TeamId { get; private set; }

    public DateTime CreationDate { get; private set; }
    public string? Message { get; private set; }

    //todo add validation
    public Contribution(ContributionType type, Guid senderId, Guid receiverId,
                        Guid? hackathonId = null, Guid? teamId = null, string? message = null)
    {
        Type = type;
        SenderId = RequireId(senderId, nameof(senderId));
        ReceiverId = RequireId(receiverId, nameof(receiverId));
        HackathonId = hackathonId;
        TeamId = teamId;
        Message = message;
        Status = ContributionStatus.Pending;
        CreationDate = DateTime.UtcNow;
    }

    public void Accept() => Status = ContributionStatus.Accepted;

    public void Decline() => Status = ContributionStatus.Declined;
}
