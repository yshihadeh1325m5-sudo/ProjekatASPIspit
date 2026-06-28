using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Teams.Application.Commands.CreateTeam;
using Modules.Teams.Application.Commands.UpdateTeam;
using Modules.Teams.Application.Teams.Commands.CreateTeam;
using Modules.Teams.Application.Teams.Queries.GetTeams;
using Modules.Teams.Domain;
using Modules.Teams.Infrastructure;

namespace Modules.Teams.Infrastructure;

public static class TeamsModuleDependencyInjection
{
    public static IServiceCollection AddTeamsModule(this IServiceCollection services, IConfiguration configuration)
    {
        // Registrujemo fabriku umesto direktnog DbContext servisa
        services.AddDbContextFactory<TeamsDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ITeamRepository, TeamRepository>();

        services.AddTransient<CreateTeamCommandHandler>();
        services.AddTransient<GetTeamsQueryHandler>();
        services.AddTransient<DeleteTeamCommandHandler>();
        services.AddTransient<UpdateTeamCommandHandler>();

        return services;
    }
}