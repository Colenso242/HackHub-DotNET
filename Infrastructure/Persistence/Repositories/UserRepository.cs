using HackHub_DotNET.Domain;
using HackHub_DotNET.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HackHub_DotNET.Infrastructure.Persistence.Repositories;

public sealed class UserRepository(HackHubDbContext context) : Repository<User>(context), IUserRepository
{
    public Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default)
        => Set.SingleOrDefaultAsync(u => u.Username == username, cancellationToken);

    public Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken = default)
        => Set.AnyAsync(u => u.Username == username, cancellationToken);
}
