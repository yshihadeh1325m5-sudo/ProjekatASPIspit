using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modules.Teams.Domain;

namespace Modules.Teams.Infrastructure;

public class TeamRepository : ITeamRepository
{
    private readonly TeamsDbContext _context;

    // Ubrizgavamo pravi kontekst koji smo upravo napravili
    public TeamRepository(TeamsDbContext context)
    {
        _context = context;
    }

    // 1. Čitanje svih timova iz prave SQL baze
    public async Task<IEnumerable<Team>> GetAllAsync()
    {
        return await _context.Teams.ToListAsync();
    }

    // 2. Čitanje jednog tima po ID-ju
    public async Task<Team?> GetByIdAsync(Guid id)
    {
        return await _context.Teams.FindAsync(id);
    }

    // 3. Upisivanje novog tima u pravu SQL bazu
    public async Task AddAsync(Team team)
    {
        await _context.Teams.AddAsync(team);
        await _context.SaveChangesAsync();
    }
}