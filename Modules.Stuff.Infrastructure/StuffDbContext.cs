using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Modules.Stuff.Domain;

namespace Modules.Stuff.Infrastructure
{
    public class StuffDbContext : DbContext
    {
        public StuffDbContext(DbContextOptions<StuffDbContext> options) : base(options)
        {
        }

        public DbSet<StuffItem> StuffItems { get; set; } = null!;
    }
}