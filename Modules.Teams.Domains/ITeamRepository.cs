using Shared.Kernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Modules.Teams.Domain;

public interface ITeamRepository: IRepository<Team>
{
    Task<Team?> GetByIdAsync(Guid id);
    Task<IEnumerable<Team>> GetAllAsync();
    Task AddAsync(Team team);
    Task DeleteAsync(Guid id);
    Task UpdateAsync(Team team);
}