using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Coaches.Infrastructure
{
    public class CoachesDbContextFactory : IDesignTimeDbContextFactory<CoachesDbContext>
    {
        public CoachesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CoachesDbContext>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ProjekatASPIspitDb;Trusted_Connection=True;TrustServerCertificate=True;");

            return new CoachesDbContext(optionsBuilder.Options);
        }
    }

   
}
