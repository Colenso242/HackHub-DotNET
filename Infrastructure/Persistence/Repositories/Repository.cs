using HackHub_DotNET.Domain;
using HackHub_DotNET.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HackHub_DotNET.Infrastructure.Persistence.Repositories;

public class Repository<T>(HackHubDbContext context) : IRepository<T>
    where T : class, IAggregateRoot
{
    protected HackHubDbContext Context { get; } = context;
    protected DbSet<T> Set => Context.Set<T>();

    public async Task<T?> GetByIdAsync(Guid id)
        => await Set.FindAsync([id]);
    

    public async Task AddAsync(T entity)
        => await Set.AddAsync(entity);

    public async Task<int> CommitAsync()
        => await Context.SaveChangesAsync();
}
