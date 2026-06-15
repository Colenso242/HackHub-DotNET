using HackHub_DotNET.Domain.Enums;
using HackHub_DotNET.Domain.ValueObjects;

namespace HackHub_DotNET.Domain;

public class Hackathon : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public string Rules { get; private set; }
    public string Location { get; private set; }
    public double Prize { get; private set; }
    public DateTime EnrollmentDeadline { get; private set; }
    public DateRange Period { get; private set; }
    public HackathonState State { get; private set; }
    public int MaxTeamSize { get; private set; }
    public Guid OrganizerId { get; private set; }
    public Guid JudgeId { get; private set; }

    // Optional: there is no winner until the hackathon concludes.
    public Guid? WinnerId { get; private set; }

    private readonly HashSet<Guid> _mentorIds = new();
    private readonly HashSet<Guid> _teamIds = new();
    public IReadOnlyCollection<Guid> MentorIds => _mentorIds;
    public IReadOnlyCollection<Guid> TeamIds => _teamIds;

    private Hackathon() { } // for EF Core

    //TODO add validation if needed once builder is implemented
    public Hackathon(string name, string rules, string location, double prize,
                     DateTime enrollmentDeadline, DateRange period,
                     HackathonState state, int maxTeamSize, Guid organizerId, Guid judgeId,
                     IEnumerable<Guid>? mentorIds = null)
    {
        Name = Require(name, nameof(name));
        Rules = Require(rules, nameof(rules));
        Location = Require(location, nameof(location));
        Prize = prize;
        EnrollmentDeadline = enrollmentDeadline;
        Period = period ?? throw new ArgumentNullException(nameof(period));
        State = state;
        MaxTeamSize = maxTeamSize;
        OrganizerId = RequireId(organizerId, nameof(organizerId));
        JudgeId = RequireId(judgeId, nameof(judgeId));

        if (mentorIds == null) return;
        foreach (var mentorId in mentorIds)
            AddMentor(mentorId);
    }

    public void AddMentor(Guid mentorId) => _mentorIds.Add(RequireId(mentorId, nameof(mentorId)));

    public void EnrollTeam(Guid teamId) => _teamIds.Add(RequireId(teamId, nameof(teamId)));

    public void ProclaimWinner(Guid teamId)
    {
        RequireId(teamId, nameof(teamId));
        if (!_teamIds.Contains(teamId))
            throw new InvalidOperationException("The winner must be a team enrolled in this hackathon.");

        WinnerId = teamId;
        State = HackathonState.Concluded;
    }

    private static string Require(string value, string paramName)
        => string.IsNullOrWhiteSpace(value) ? throw new ArgumentException($"{paramName} is required.", paramName) : value;
}
