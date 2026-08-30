using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Modules.Matches.Domain;

namespace Modules.Matches.Infrastructure
{
    public class MatchesDbContext : DbContext
    {
        public MatchesDbContext(DbContextOptions<MatchesDbContext> options) : base(options)
        {
        }

        // Ovo je ključna linija - mapira tvoj entitet na tabelu u bazi
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ovde možeš definisati konfiguracije ako ti zatrebaju kasnije, 
            // npr. za Id ili odnose između tabela.
            modelBuilder.Entity<Match>().HasKey(m => m.Id);
        }
    }
}
