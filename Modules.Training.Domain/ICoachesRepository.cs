using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Coaches.Domain
{
    public interface ICoachesRepository
    {
        Task<CoachesItem?> GetByIdAsync(Guid id);
        Task<IEnumerable<CoachesItem>> GetAllAsync();
        Task AddAsync(CoachesItem coaches);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(CoachesItem coaches);
    }
}
