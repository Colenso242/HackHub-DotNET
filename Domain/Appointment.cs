using HackHub_DotNET.Domain.ValueObjects;

namespace HackHub_DotNET.Domain;

public class Appointment : BaseEntity, IAggregateRoot
{
    public Guid MentorId { get; private set; }
    public Guid TeamId { get; private set; }
    public Guid HackathonId { get; private set; }
    public DateRange Slot { get; private set; }

    // Optional: an appointment may not have a meeting link yet.
    public Url? MeetingUrl { get; private set; }

    private Appointment() { } // for EF Core

    public Appointment(Guid mentorId, Guid teamId, Guid hackathonId, DateRange slot, Url? meetingUrl = null)
    {
        MentorId = RequireId(mentorId, nameof(mentorId));
        TeamId = RequireId(teamId, nameof(teamId));
        HackathonId = RequireId(hackathonId, nameof(hackathonId));
        Slot = slot ?? throw new ArgumentNullException(nameof(slot));
        MeetingUrl = meetingUrl;
    }
}
