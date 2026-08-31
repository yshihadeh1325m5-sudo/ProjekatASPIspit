using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;
using Modules.Matches.Domain;
using Shared.Kernel;
namespace Modules.Matches.Domain
{
    public interface IMatchRepository:IRepository<Match>
    {
        Task<IEnumerable<Match>> GetAllAsync();
        Task<Match?> GetByIdAsync(Guid id);
        Task AddAsync(Match match);
        Task UpdateAsync(Match match);
        Task DeleteAsync(Guid id); 
    }
}