using HackHub_DotNET.Domain;
using HackHub_DotNET.Domain.Repositories;

namespace HackHub_DotNET.Infrastructure.Persistence.Repositories;

public sealed class HackathonRepository(HackHubDbContext context) : Repository<Hackathon>(context), IHackathonRepository;
