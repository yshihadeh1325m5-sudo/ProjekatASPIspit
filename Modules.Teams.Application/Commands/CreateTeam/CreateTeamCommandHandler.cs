using System;
using System.Collections.Generic;
using System.Text;

using Modules.Teams.Domain;

namespace Modules.Teams.Application.Teams.Commands.CreateTeam
{

    public class CreateTeamCommandHandler
    {
        private readonly ITeamRepository _teamRepository;

       
        public CreateTeamCommandHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task HandleAsync(CreateTeamCommand command)
        {
         
            var team = new Team(Guid.NewGuid(), command.Name, command.Stadium);

            await _teamRepository.AddAsync(team);
        }
    }
}