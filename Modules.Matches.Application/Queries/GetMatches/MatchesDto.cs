using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Matches.Application.Queries.GetMatches
{

    public class MatchesDto
    {
        public Guid Id { get; set; }
        public Guid HomeTeamId { get; set; }
        public Guid AwayTeamId { get; set; }
        public DateTime MatchDate { get; set; }

        public MatchesDto(Guid id, Guid homeTeamId, Guid awayTeamId, DateTime matchDate)
        {
            Id = id;
            HomeTeamId = homeTeamId;
            AwayTeamId = awayTeamId;
            MatchDate = matchDate;
        }
    }
}
