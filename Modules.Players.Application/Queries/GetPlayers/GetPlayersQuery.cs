using Modules.Matches.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Matches.Application.Queries.GetMatches
{

    public class GetPlayersQuery
    {
        private readonly IMatchRepository _repository;

        public GetPlayersQuery(IMatchRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PlayersDto>> HandleAsync(GetPlayersQuery query)
        {

            var matches = await _repository.GetAllAsync();

            return matches.Select(m => new PlayersDto(
                m.Id,
                m.HomeTeamId,
                m.AwayTeamId,
                m.MatchDate
            ));
        }
    }
}
