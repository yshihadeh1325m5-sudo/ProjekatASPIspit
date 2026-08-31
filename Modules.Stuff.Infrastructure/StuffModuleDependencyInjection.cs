using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Stuff.Application.Commands.CreateStuff;
using Modules.Stuff.Application.Commands.UpdateStuff;
using Modules.Stuff.Application.Queries.GetStuff;
using Modules.Stuff.Domain;
using Modules.Stuff.Infrastructure;
using Modules.Stuff.Ui.View;
using Modules.Stuff.Ui.Viewmodels;

namespace Modules.Stuff.Infrastructure
{
    public static class StuffModuleDependencyInjection
    {
        public static IServiceCollection AddStuffModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<StuffDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IStuffRepository, StuffRepository>();

            services.AddTransient<CreateStuffCommandHandler>();
            services.AddTransient<GetStuffQueryHandler>();
            services.AddTransient<DeleteStuffCommandHandler>();
            services.AddTransient<UpdateStuffCommandHandler>();

            services.AddTransient<StuffViewModel>();
            services.AddTransient<StuffView>();

            return services;
        }
    }
}