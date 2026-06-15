using HackHub_DotNET.Domain;
using Microsoft.EntityFrameworkCore;

namespace HackHub_DotNET.Infrastructure.Persistence;

public class HackHubDbContext(DbContextOptions<HackHubDbContext> options) : DbContext(options)
{
    // One DbSet per aggregate root.
    public DbSet<User> Users => Set<User>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<Hackathon> Hackathons => Set<Hackathon>();
    public DbSet<Submission> Submissions => Set<Submission>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<Contribution> Contributions => Set<Contribution>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HackHubDbContext).Assembly);
    }
}
