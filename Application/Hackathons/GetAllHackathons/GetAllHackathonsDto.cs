using HackHub_DotNET.Domain.Enums;

namespace HackHub_DotNET.Application.Hackathons.GetAllHackathons;

public record GetAllHackathonsDto(
    Guid Id,
    string Name,
    string Location,
    HackathonState State,
    double Prize,
    int MaxTeamSize
);