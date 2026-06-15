namespace HackHub_DotNET.Domain.Repositories;

// The generic constraint is the whole point: only aggregate roots get a
// repository, because the root is the unit a transaction loads and saves.
public interface IRepository<T> where T : class, IAggregateRoot
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<T>> ListAsync(CancellationToken cancellationToken = default);

    Task AddAsync(T entity, CancellationToken cancellationToken = default);

    void Update(T entity);

    void Remove(T entity);
}
