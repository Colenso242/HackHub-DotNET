using HackHub_DotNET.Domain;
using HackHub_DotNET.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HackHub_DotNET.Infrastructure.Persistence.Repositories;

public class Repository<T>(HackHubDbContext context) : IRepository<T>
    where T : class, IAggregateRoot
{
    protected HackHubDbContext Context { get; } = context;
    protected DbSet<T> Set => Context.Set<T>();

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await Set.FindAsync([id], cancellationToken);

    public async Task<IReadOnlyList<T>> ListAsync(CancellationToken cancellationToken = default)
        => await Set.ToListAsync(cancellationToken);

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        => await Set.AddAsync(entity, cancellationToken);

    public void Update(T entity) => Set.Update(entity);

    public void Remove(T entity) => Set.Remove(entity);
}
