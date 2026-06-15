using HackHub_DotNET.Domain.Enums;

namespace HackHub_DotNET.Domain;

public class Team : BaseEntity
{
    public string Name { get; private set; }
    public User Leader { get; private set; }

    // Optional: a team may not currently be enrolled in a hackathon.
    public Hackathon? CurrentHackathon { get; internal set; }
    public bool Deleted { get; private set; }

    public ICollection<User> Members { get; private set; } = new HashSet<User>();
    public ICollection<Submission> Submissions { get; private set; } = new HashSet<Submission>();

    //TODO constructor doesnt establish relationship to user
    public Team(string name, User leader)
    {
        Name = ValidateName(name);
        Leader = leader ?? throw new ArgumentNullException(nameof(leader));
    }

    public void AddMember(User user)
    {
        ArgumentNullException.ThrowIfNull(user);
        if (Members.Contains(user)) return;
        Members.Add(user);
        user.Team = this;
        user.UserRole = UserRole.TeamMember;
    }
    
    //Todo UserRole is not updated
    public void RemoveMember(User user)
    {
        ArgumentNullException.ThrowIfNull(user);
        if (Members.Remove(user))
            user.Team = null;
    }

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