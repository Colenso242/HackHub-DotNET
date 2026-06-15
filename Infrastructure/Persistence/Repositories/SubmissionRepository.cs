using HackHub_DotNET.Domain;
using HackHub_DotNET.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HackHub_DotNET.Infrastructure.Persistence.Repositories;

public sealed class SubmissionRepository(HackHubDbContext context) : Repository<Submission>(context), ISubmissionRepository
{
    public async Task<IReadOnlyList<Submission>> ListByHackathonAsync(Guid hackathonId, CancellationToken cancellationToken = default)
        => await Set.Where(s => s.HackathonId == hackathonId).ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<Submission>> ListByTeamAsync(Guid teamId, CancellationToken cancellationToken = default)
        => await Set.Where(s => s.TeamId == teamId).ToListAsync(cancellationToken);
}
