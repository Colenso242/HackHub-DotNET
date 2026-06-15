using HackHub_DotNET.Domain.Enums;

namespace HackHub_DotNET.Domain;

public class Contribution : BaseEntity
{
    public ContributionType Type { get; private set; }
    public ContributionStatus Status { get; private set; }
    public User Sender { get; private set; }
    public User Receiver { get; private set; }

    // Optional: a contribution is not necessarily scoped to a hackathon or a team.
    public Hackathon? Hackathon { get; private set; }
    public Team? Team { get; private set; }

    public DateTime CreationDate { get; private set; }
    public string? Message { get; private set; }

    public Contribution(ContributionType type, User sender, User receiver,
                        Hackathon? hackathon = null, Team? team = null, string? message = null)
    {
        Type = type;
        Sender = sender ?? throw new ArgumentNullException(nameof(sender));
        Receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
        Hackathon = hackathon;
        Team = team;
        Message = message;
        Status = ContributionStatus.Pending;
        CreationDate = DateTime.UtcNow;
    }

    public void Accept() => Status = ContributionStatus.Accepted;

    public void Decline() => Status = ContributionStatus.Declined;
}