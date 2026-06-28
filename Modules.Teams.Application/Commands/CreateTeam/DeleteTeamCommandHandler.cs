using Modules.Teams.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Teams.Application.Commands.CreateTeam
{
    public class DeleteTeamCommandHandler
    {
        private readonly ITeamRepository _repository; // Samo interfejs!

        public DeleteTeamCommandHandler(ITeamRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(DeleteTeamCommand command)
        {
            // Komanda samo poziva metodu repozitorijuma
            await _repository.DeleteAsync(command.Id);
        }
    }
}
