using System;
using System.Threading.Tasks;
using Modules.Matches.Domain;
using Microsoft.EntityFrameworkCore;

namespace Modules.Matches.Application.Commands.CreateMatch
{
    public class CreateMatchCommandHandler
    {
        private readonly IMatchRepository _matchRepository;

        public CreateMatchCommandHandler(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public async Task HandleAsync(CreateMatchCommand command)
        {
            var match = new Match(command.HomeTeamId, command.AwayTeamId, command.HomeScore, command.AwayScore, command.MatchDate);

            await _matchRepository.AddAsync(match);
        }
    }
}