using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modules.Stuff.Domain;

namespace Modules.Stuff.Infrastructure
{
    public class StuffRepository : IStuffRepository
    {
        private readonly IDbContextFactory<StuffDbContext> _contextFactory;

        public StuffRepository(IDbContextFactory<StuffDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<StuffItem>> GetAllAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.StuffItems.ToListAsync();
        }

        public async Task<StuffItem?> GetByIdAsync(Guid id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.StuffItems.FindAsync(id);
        }

        public async Task AddAsync(StuffItem stuff)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            await context.StuffItems.AddAsync(stuff);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var stuff = await context.StuffItems.FindAsync(id);
            if (stuff != null)
            {
                context.StuffItems.Remove(stuff);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(StuffItem stuff)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var existingStuff = await context.StuffItems.FindAsync(stuff.Id);

            if (existingStuff != null)
            {
                existingStuff.UpdateDetails(stuff.Name, stuff.Code, stuff.Price, stuff.Description);
                await context.SaveChangesAsync();
            }
        }
    }
}