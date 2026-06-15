namespace HackHub_DotNET.Domain;

public class Team : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public Guid LeaderId { get; private set; }
    public bool Deleted { get; private set; }

    private readonly HashSet<Guid> _memberIds = new();
    public IReadOnlyCollection<Guid> MemberIds => _memberIds;

    public Team(string name, Guid leaderId)
    {
        Name = ValidateName(name);
        LeaderId = RequireId(leaderId, nameof(leaderId));
    }

    public void AddMember(Guid userId) => _memberIds.Add(RequireId(userId, nameof(userId)));

    public void RemoveMember(Guid userId) => _memberIds.Remove((RequireId(userId,nameof(userId))));

    public bool IsLeader(Guid userId) => userId == LeaderId;

    // Soft delete (mirrors the reference @SQLDelete behaviour).
    public void MarkDeleted() => Deleted = true;

    private static string ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Team name is required.", nameof(name));
        if (name.Length > 25)
            throw new ArgumentException("Team name must be at most 25 characters.", nameof(name));
        return name;
    }
}
