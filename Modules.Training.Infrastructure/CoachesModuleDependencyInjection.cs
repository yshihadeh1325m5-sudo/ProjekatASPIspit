using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Modules.Coaches.Domain;
using Modules.Coaches.Application.Commands.CreateCoaches;
using Modules.Coaches.Application.Queries.GetCoaches;
using Modules.Coaches.Application.Commands.UpdateCoaches;
using Modules.Coaches.Ui.Viewmodels;



namespace Modules.Coaches.Infrastructure
{
    public static class CoachesModuleDependencyInjection
    {
        public static IServiceCollection AddCoachesModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<CoachesDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICoachesRepository, CoachesRepository>();

            services.AddTransient<CreateCoachesCommandHandler>();
            services.AddTransient<GetCoachesQueryHandler>();
            services.AddTransient<DeleteCoachesCommandHandler>();
            services.AddTransient<UpdateCoachesCommandHandler>();

            services.AddTransient<CoachesViewModel>();

            return services;
        }
    }
    
    
}
