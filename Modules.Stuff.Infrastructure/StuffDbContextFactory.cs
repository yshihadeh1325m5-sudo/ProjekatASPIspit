using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Modules.Stuff.Infrastructure
{
    public class StuffDbContextFactory : IDesignTimeDbContextFactory<StuffDbContext>
    {
        public StuffDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StuffDbContext>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ProjekatASPIspitDb;Trusted_Connection=True;TrustServerCertificate=True;");

            return new StuffDbContext(optionsBuilder.Options);
        }
    }
}