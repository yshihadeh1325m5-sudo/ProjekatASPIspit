using Modules.Matches.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Matches.Application.Commands.CreateMatch
{
    public class DeleteMatchCommandHandler
    {
        private readonly IMatchRepository _repository; // Samo interfejs!

        public DeleteMatchCommandHandler(IMatchRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(DeleteMatchCommand command)
        {
            // Komanda samo poziva metodu repozitorijuma
            await _repository.DeleteAsync(command.Id);
        }
    }
}
