using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Matches.Infrastructure
{
    public class MatchesDbContextFactory : IDesignTimeDbContextFactory<MatchesDbContext>
    {
        public MatchesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MatchesDbContext>();

            // Mora biti identičan connection string koji koristiš u aplikaciji!
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ProjekatASPispitDB;Trusted_Connection=True;");

            return new MatchesDbContext(optionsBuilder.Options);
        }
    }
}
