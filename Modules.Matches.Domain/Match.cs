using System;
using Shared.Kernel;

namespace Modules.Matches.Domain
{
    public class Match : BaseEntity
    {
        public Guid Id { get; private set; }
        public Guid HomeTeamId { get; private set; }
        public Guid AwayTeamId { get; private set; }
        public DateTime MatchDate { get; private set; }
        public int HomeScore { get; private set; }
        public int AwayScore { get; private set; }

        public Match(Guid homeTeamId, Guid awayTeamId, DateTime matchDate)
        {
            Id = Guid.NewGuid();
            HomeTeamId = homeTeamId;
            AwayTeamId = awayTeamId;
            MatchDate = matchDate;
            HomeScore = 0;
            AwayScore = 0;
        }

        public Match(Guid homeTeamId, Guid awayTeamId, int homeScore, int awayScore, DateTime matchDate)
        {
            Id = Guid.NewGuid();
            HomeTeamId = homeTeamId;
            AwayTeamId = awayTeamId;
            HomeScore = homeScore;
            AwayScore = awayScore;
            MatchDate = matchDate;
        }

        public void UpdateScore(int homeScore, int awayScore)
        {
            HomeScore = homeScore;
            AwayScore = awayScore;
        }

        public void UpdateDetails(Guid homeTeamId, Guid awayTeamId, int homeScore, int awayScore, DateTime matchDate)
        {
            HomeTeamId = homeTeamId;
            AwayTeamId = awayTeamId;
            HomeScore = homeScore;
            AwayScore = awayScore;
            MatchDate = matchDate;
        }
    }
}