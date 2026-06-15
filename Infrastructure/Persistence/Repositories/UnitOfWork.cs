using HackHub_DotNET.Domain.Repositories;

namespace HackHub_DotNET.Infrastructure.Persistence.Repositories;

public sealed class UnitOfWork(HackHubDbContext context) : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => context.SaveChangesAsync(cancellationToken);
}
