namespace HackHub_DotNET.Domain.Repositories;

public interface ISubmissionRepository : IRepository<Submission>
{
    // A submission references its hackathon/team by id rather than via a
    // navigation, so these lookups replace the old owned collections.
    Task<IReadOnlyList<Submission>> ListByHackathonAsync(Guid hackathonId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Submission>> ListByTeamAsync(Guid teamId, CancellationToken cancellationToken = default);
}
