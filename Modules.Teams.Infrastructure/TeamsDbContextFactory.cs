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

        // Ovde upiši tvoj konekcioni string na bazu. EF alat će koristiti ovo samo za pravljenje migracije!
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ProjekatASPIspitDb;Trusted_Connection=True;TrustServerCertificate=True;");

        return new TeamsDbContext(optionsBuilder.Options);
    }
}