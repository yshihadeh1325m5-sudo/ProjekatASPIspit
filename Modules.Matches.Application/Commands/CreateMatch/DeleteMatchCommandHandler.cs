using Modules.Matches.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Matches.Application.Commands.CreateMatch
{
    public class DeleteMatchCommandHandler
    {
        private readonly IMatchRepository _repository; 

        public DeleteMatchCommandHandler(IMatchRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(DeleteMatchCommand command)
        {

            await _repository.DeleteAsync(command.Id);
        }
    }
}
