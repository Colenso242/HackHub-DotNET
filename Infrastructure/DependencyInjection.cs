using HackHub_DotNET.Domain.Repositories;
using HackHub_DotNET.Infrastructure.Persistence;
using HackHub_DotNET.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HackHub_DotNET.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //todo validate connection string
        services.AddDbContext<HackHubDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<IHackathonRepository, HackathonRepository>();
        services.AddScoped<ISubmissionRepository, SubmissionRepository>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IContributionRepository, ContributionRepository>();

        return services;
    }
}
