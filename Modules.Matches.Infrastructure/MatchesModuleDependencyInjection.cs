using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Modules.Matches.Application.Commands.CreateMatch;
using Modules.Matches.Application.Queries.GetMatches;
using Modules.Matches.Domain;

namespace Modules.Matches.Infrastructure
{
    public static class MatchesModuleDependencyInjection
    {
        public static IServiceCollection AddMatchesModule(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. Registracija DbContext-a
            services.AddDbContextFactory<MatchesDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // 2. Registracija Repository-ja
            services.AddScoped<IMatchRepository, MatchRepository>();

            // 3. Registracija Handlera (Command & Query)
            services.AddTransient<CreateMatchCommandHandler>();
            services.AddTransient<GetMatchesQuery>();

            return services;
        }
    }
}
