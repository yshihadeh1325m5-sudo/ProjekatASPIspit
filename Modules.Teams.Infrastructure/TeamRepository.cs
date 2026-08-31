using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modules.Teams.Domain;



namespace Modules.Teams.Infrastructure;

public class TeamRepository : ITeamRepository
{
    private readonly IDbContextFactory<TeamsDbContext> _contextFactory;


    public TeamRepository(IDbContextFactory<TeamsDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<Team>> GetAllAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Teams.ToListAsync();
    }

    public async Task<Team?> GetByIdAsync(Guid id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Teams.FindAsync(id);
    }

    public async Task AddAsync(Team team)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        await context.Teams.AddAsync(team);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var team = await context.Teams.FindAsync(id);
        if (team != null)
        {
            context.Teams.Remove(team);
            await context.SaveChangesAsync();
        }
    }
    public async Task UpdateAsync(Team team)
    {
    
        using var context = await _contextFactory.CreateDbContextAsync();

        var existingTeam = await context.Teams.FindAsync(team.Id);

        if (existingTeam != null)
        {
 
            existingTeam.UpdateDetails(team.Name, team.Stadium);
            await context.SaveChangesAsync();
        }
    }
}