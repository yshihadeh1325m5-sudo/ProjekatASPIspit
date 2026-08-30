using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modules.Matches.Domain;
using DomainMatch = Modules.Matches.Domain.Match;

namespace Modules.Matches.Infrastructure
{
    public class MatchRepository : IMatchRepository
    {
        private readonly MatchesDbContext _context;

        public MatchRepository(MatchesDbContext context) => _context = context;

        public async Task<IEnumerable<DomainMatch>> GetAllAsync() =>
            await _context.Matches.ToListAsync();

        public async Task<DomainMatch?> GetByIdAsync(Guid id) =>
            await _context.Matches.FindAsync(id);

        public async Task AddAsync(DomainMatch match)
        {
            await _context.Matches.AddAsync(match);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DomainMatch match)
        {
            _context.Matches.Update(match);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match != null)
            {
                _context.Matches.Remove(match);
                await _context.SaveChangesAsync();
            }
        }
    }
}