using Shared.Kernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Modules.Coaches.Domain
{
    public interface ICoachesRepository : IRepository<CoachesItem>
    {
        Task<CoachesItem?> GetByIdAsync(Guid id);
        Task<IEnumerable<CoachesItem>> GetAllAsync();
        Task AddAsync(CoachesItem coaches);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(CoachesItem coaches);
    }
}
