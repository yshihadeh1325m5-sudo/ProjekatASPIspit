using Modules.Teams.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Teams.Application.Commands.CreateTeam
{
    public class DeleteTeamCommandHandler
    {
        private readonly ITeamRepository _repository; 

        public DeleteTeamCommandHandler(ITeamRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(DeleteTeamCommand command)
        {

            await _repository.DeleteAsync(command.Id);
        }
    }
}
