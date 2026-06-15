namespace HackHub_DotNET.Domain.Repositories;

// Repositories stage changes; the unit of work commits them in one transaction.
public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
