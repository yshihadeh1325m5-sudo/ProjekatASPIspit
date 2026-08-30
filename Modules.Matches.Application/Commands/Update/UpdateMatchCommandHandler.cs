using Modules.Matches.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Modules.Matches.Application.Commands.Update
{
    public class UpdateTeamCommandHandler
    {
        private readonly IMatchRepository _repository;

        public UpdateTeamCommandHandler(IMatchRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(UpdateMatchCommand command)
        {
            var match = await _repository.GetByIdAsync(command.Id);


            if (match != null)
            {

                match.UpdateDetails(command.HomeScore, command.AwayScore);

                await _repository.UpdateAsync(match);
            }
        }
    }
}
