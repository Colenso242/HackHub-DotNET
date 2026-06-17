using HackHub_DotNET.Domain;
using HackHub_DotNET.Domain.Repositories;

namespace HackHub_DotNET.Infrastructure.Persistence.Repositories;

public class HackathonRepository(HackHubDbContext context) : IHackathonRepository
{
    public async Task<Hackathon?> GetByIdAsync(Guid id)
    {
        return await context.Hackathons.FindAsync(id);
    }

    public async Task AddAsync(Hackathon hackathon)
    {
        await context.Hackathons.AddAsync(hackathon);
    }
    
    public async Task<int> CommitAsync()
    {
        return await context.SaveChangesAsync();
    }
}