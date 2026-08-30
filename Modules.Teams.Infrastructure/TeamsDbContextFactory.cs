using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Modules.Teams.Infrastructure;

public class TeamsDbContextFactory : IDesignTimeDbContextFactory<TeamsDbContext>
{
    public TeamsDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TeamsDbContext>();

        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ProjekatASPIspitDb;Trusted_Connection=True;TrustServerCertificate=True;");

        return new TeamsDbContext(optionsBuilder.Options);
    }
}