using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Modules.Coaches.Domain;

namespace Modules.Coaches.Infrastructure
{
    public class CoachesDbContext : DbContext
    {
        public CoachesDbContext(DbContextOptions<CoachesDbContext> options) : base(options)
        {
        }

        public DbSet<CoachesItem> CoachesItems { get; set; } = null!;
    }
    
}
