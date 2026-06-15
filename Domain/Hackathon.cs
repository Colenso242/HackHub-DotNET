using HackHub_DotNET.Domain.Enums;

namespace HackHub_DotNET.Domain;

public class Hackathon : BaseEntity
{
    public string Name { get; private set; }
    public string Rules { get; private set; }
    public string Location { get; private set; }
    public double Prize { get; private set; }
    public DateTime EnrollmentDeadline { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public HackathonState State { get; private set; }
    public int MaxTeamSize { get; private set; }
    public User Organizer { get; private set; }
    public User Judge { get; private set; }

    // Optional: there is no winner until the hackathon concludes.
    public Team? Winner { get; private set; }

    public ICollection<User> Mentors { get; private set; } = new HashSet<User>();
    public ICollection<Team> Teams { get; private set; } = new HashSet<Team>();
    public ICollection<Submission> Submissions { get; private set; } = new HashSet<Submission>();

    //TODO add validation if needed once builder is implemented
    public Hackathon(string name, string rules, string location, double prize,
                     DateTime enrollmentDeadline, DateTime startDate, DateTime endDate,
                     HackathonState state, int maxTeamSize, User organizer, User judge,
                     IEnumerable<User>? mentors = null)
    {
        Name = Require(name, nameof(name));
        Rules = Require(rules, nameof(rules));
        Location = Require(location, nameof(location));
        Prize = prize;
        EnrollmentDeadline = enrollmentDeadline;
        StartDate = startDate;
        EndDate = endDate;
        State = state;
        MaxTeamSize = maxTeamSize;
        Organizer = organizer ?? throw new ArgumentNullException(nameof(organizer));
        Judge = judge ?? throw new ArgumentNullException(nameof(judge));

        if (mentors == null) return;
        foreach (var mentor in mentors)
            AddMentor(mentor);
    }

    private void AddMentor(User mentor)
    {
        ArgumentNullException.ThrowIfNull(mentor);
        if (Mentors.Contains(mentor)) return;
        Mentors.Add(mentor);
        mentor.Hackathon = this;
    }

    public void AddTeam(Team team)
    {
        ArgumentNullException.ThrowIfNull(team);
        if (Teams.Contains(team)) return;
        Teams.Add(team);
        team.CurrentHackathon = this;
    }

    public void AddSubmission(Submission submission)
    {
        ArgumentNullException.ThrowIfNull(submission);
        if (!Submissions.Contains(submission))
            Submissions.Add(submission);
    }

    public void ProclaimWinner(Team winner)
    {
        Winner = winner ?? throw new ArgumentNullException(nameof(winner));
        State = HackathonState.Concluded;

        // Detach mentors and teams from the concluded hackathon.
        foreach (var mentor in Mentors) mentor.Hackathon = null;
        foreach (var team in Teams) team.CurrentHackathon = null;
    }

    private static string Require(string value, string paramName)
    {
        return string.IsNullOrWhiteSpace(value) ? throw new ArgumentException($"{paramName} is required.", paramName) : value;
    }
}