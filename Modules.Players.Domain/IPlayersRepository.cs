using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Modules.Matches.Domain;

namespace Modules.Matches.Domain
{
    public interface IPlayersRepository
    {
        Task<IEnumerable<Players>> GetAllAsync();
        Task<Players?> GetByIdAsync(Guid id);
        Task AddAsync(Players match);
        Task UpdateAsync(Players match);
        Task DeleteAsync(Guid id); 
    }
}