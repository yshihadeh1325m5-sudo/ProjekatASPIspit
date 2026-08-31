using System;
using System.Threading.Tasks;
using Modules.Matches.Domain;

namespace Modules.Matches.Application.Commands.Update
{
    public class UpdateMatchCommandHandler
    {
        private readonly IMatchRepository _repository;

        public UpdateMatchCommandHandler(IMatchRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(UpdatePlayersCommand command)
        {
            var match = await _repository.GetByIdAsync(command.Id);

            if (match != null)
            {
                match.UpdateDetails(command.HomeTeamId, command.AwayTeamId, command.HomeScore, command.AwayScore, command.MatchDate);

                await _repository.UpdateAsync(match);
            }
        }
    }
}