using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Matches.Application.Commands.Update
{
    public record UpdatePlayersCommand(Guid Id,Guid HomeTeamId,Guid AwayTeamId,int HomeScore,int AwayScore,DateTime MatchDate);
}




