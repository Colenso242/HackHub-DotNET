using HackHub_DotNET.Domain;
using Microsoft.EntityFrameworkCore;

namespace HackHub_DotNET.Persistence;

public class HackHubDbContext(DbContextOptions<HackHubDbContext> options) : DbContext(options)
{
    public DbSet<Hackathon> Hackathons => Set<Hackathon>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<Contribution>  Contributions => Set<Contribution>();
    public DbSet<Submission> Submissions => Set<Submission>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}