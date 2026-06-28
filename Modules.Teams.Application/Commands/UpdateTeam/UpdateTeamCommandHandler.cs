using Modules.Teams.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Teams.Application.Commands.UpdateTeam
{
    public class UpdateTeamCommandHandler
    {
        private readonly ITeamRepository _repository;

        public UpdateTeamCommandHandler(ITeamRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(UpdateTeamCommand command)
        {
            var team = await _repository.GetByIdAsync(command.Id);


            if (team != null)
            {
         
                team.UpdateDetails(command.Name, command.Stadium);

                await _repository.UpdateAsync(team);
            }
        }
    }
}