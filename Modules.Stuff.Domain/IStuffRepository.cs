using Shared.Kernel;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Modules.Stuff.Domain
{
    public interface IStuffRepository: IRepository<StuffItem>
    {
        Task<StuffItem?> GetByIdAsync(Guid id);
        Task<IEnumerable<StuffItem>> GetAllAsync();
        Task AddAsync(StuffItem stuff);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(StuffItem stuff);
    }
}