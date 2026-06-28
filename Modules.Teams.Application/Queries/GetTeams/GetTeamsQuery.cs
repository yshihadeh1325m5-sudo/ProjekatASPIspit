using System;
using System.Collections.Generic;
using System.Text;

using Modules.Teams.Domain;

namespace Modules.Teams.Application.Teams.Queries.GetTeams;

public record GetTeamsQuery();

public class GetTeamsQueryHandler
{
    private readonly ITeamRepository _teamRepository;


    public GetTeamsQueryHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<IEnumerable<TeamDto>> HandleAsync(GetTeamsQuery query)
    {
       
        var teams = await _teamRepository.GetAllAsync();
        return teams.Select(t => new TeamDto(t.Id, t.Name, t.Stadium));
    }
}