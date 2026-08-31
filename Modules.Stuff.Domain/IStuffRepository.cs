using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modules.Stuff.Domain
{
    public interface IStuffRepository
    {
        Task<StuffItem?> GetByIdAsync(Guid id);
        Task<IEnumerable<StuffItem>> GetAllAsync();
        Task AddAsync(StuffItem stuff);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(StuffItem stuff);
    }
}