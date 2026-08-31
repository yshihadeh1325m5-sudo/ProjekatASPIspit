using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Modules.Coaches.Domain;

namespace Modules.Coaches.Infrastructure
{

    public class CoachesRepository : ICoachesRepository
    {
        private readonly IDbContextFactory<CoachesDbContext> _contextFactory;

        public CoachesRepository(IDbContextFactory<CoachesDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<CoachesItem>> GetAllAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.CoachesItems.ToListAsync();
        }

        public async Task<CoachesItem?> GetByIdAsync(Guid id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.CoachesItems.FindAsync(id);
        }

        public async Task AddAsync(CoachesItem stuff)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            await context.CoachesItems.AddAsync(stuff);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var stuff = await context.CoachesItems.FindAsync(id);
            if (stuff != null)
            {
                context.CoachesItems.Remove(stuff);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(CoachesItem coaches)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var existingStuff = await context.CoachesItems.FindAsync(coaches.Id);

            if (existingStuff != null)
            {
                existingStuff.UpdateDetails(coaches.Ime, coaches.Prezime, coaches.Licenca, coaches.OpisLicence, coaches.Ekipa);
                await context.SaveChangesAsync();
            }
        }
    }
}
