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

    
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Match>().HasKey(m => m.Id);
        }
    }
}
