using Modules.Players.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Matches.Application.Commands.CreateMatch
{
    public class DeletePlayersCommandHandler
    {
        private readonly IPlayerRsepository _repository; // Samo interfejs!

        public DeletePlayersCommandHandler(IMatchRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(DeletePlayersCommand command)
        {
            // Komanda samo poziva metodu repozitorijuma
            await _repository.DeleteAsync(command.Id);
        }
    }
}
