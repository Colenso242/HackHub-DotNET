namespace HackHub_DotNET.Domain;

public class Appointment : BaseEntity
{
    public User Mentor { get; private set; }
    public Team Team { get; private set; }
    public Hackathon Hackathon { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public string? Url { get; private set; }

    private Appointment() { } // for EF Core

    public Appointment(User mentor, Team team, Hackathon hackathon,
                       DateTime startTime, DateTime endTime, string? url = null)
    {
        Mentor = mentor ?? throw new ArgumentNullException(nameof(mentor));
        Team = team ?? throw new ArgumentNullException(nameof(team));
        Hackathon = hackathon ?? throw new ArgumentNullException(nameof(hackathon));
        StartTime = startTime;
        EndTime = endTime;
        //todo check nullability
        Url = url ?? throw new ArgumentNullException(nameof(url));
    }
}