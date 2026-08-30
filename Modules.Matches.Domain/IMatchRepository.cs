using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Modules.Matches.Domain;

namespace Modules.Matches.Domain
{
    public interface IMatchRepository
    {
        Task<IEnumerable<Match>> GetAllAsync();
        Task<Match?> GetByIdAsync(Guid id);
        Task AddAsync(Match match);
        Task UpdateAsync(Match match);
        Task DeleteAsync(Guid id); 
    }
}