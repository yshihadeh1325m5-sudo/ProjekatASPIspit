using Modules.Matches.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Matches.Application.Queries.GetMatches
{

    public class GetMatchesQuery
    {
        private readonly IMatchRepository _repository;

        public GetMatchesQuery(IMatchRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MatchesDto>> HandleAsync(GetMatchesQuery query)
        {

            var matches = await _repository.GetAllAsync();

            return matches.Select(m => new MatchesDto(
                m.Id,
                m.HomeTeamId,
                m.AwayTeamId,
                m.MatchDate
            ));
        }
    }
}
