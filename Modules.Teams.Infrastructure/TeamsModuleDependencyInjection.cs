using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Teams.Domain;
using Modules.Teams.Infrastructure;
using Modules.Teams.Application.Teams.Commands.CreateTeam;
using Modules.Teams.Application.Teams.Queries.GetTeams;

namespace Modules.Teams.Infrastructure;

public static class TeamsModuleDependencyInjection
{
    public static IServiceCollection AddTeamsModule(this IServiceCollection services, IConfiguration configuration)
    {
        // 1. Registrovan TeamsDbContext koji vuče "DefaultConnection" iz appsettings.json glavnog projekta
        // Promeni liniju 17 u ovo:
        services.AddDbContext<TeamsDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")),
            ServiceLifetime.Transient); // Dodaj ovo ovde

        // 2. Tvoj repository i handler-i ostaju registrovani
        services.AddScoped<ITeamRepository, TeamRepository>();

        services.AddTransient<CreateTeamCommandHandler>();
        services.AddTransient<GetTeamsQueryHandler>();

        return services;
    }
}