using System;

namespace Modules.Matches.Application.Commands.CreateMatch
{
    public record CreateMatchCommand(
        Guid HomeTeamId,
        Guid AwayTeamId,
        int HomeScore,
        int AwayScore,
        DateTime MatchDate
    );
}