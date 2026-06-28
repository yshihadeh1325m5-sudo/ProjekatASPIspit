using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Modules.Teams.Domain;

namespace Modules.Teams.Infrastructure;

public class TeamsDbContext : DbContext
{
    public TeamsDbContext(DbContextOptions<TeamsDbContext> options) : base(options)
    {
    }

    // Ova linija mapira tvoj domenski model sa SQL tabelom
    public DbSet<Team> Teams { get; set; } = null!;
}