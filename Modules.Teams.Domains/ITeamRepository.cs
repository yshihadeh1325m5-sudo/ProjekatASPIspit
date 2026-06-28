using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Teams.Domain;

public interface ITeamRepository
{
    Task<Team?> GetByIdAsync(Guid id);
    Task<IEnumerable<Team>> GetAllAsync();
    Task AddAsync(Team team);
    Task DeleteAsync(Guid id);
    Task UpdateAsync(Team team);
}