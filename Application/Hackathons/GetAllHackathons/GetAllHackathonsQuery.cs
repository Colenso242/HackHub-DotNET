using HackHub_DotNET.Application.Abstractions;

namespace HackHub_DotNET.Application.Hackathons.GetAllHackathons;

public record GetAllHackathonsQuery() : IQuery<IReadOnlyList<GetAllHackathonsDto>>;