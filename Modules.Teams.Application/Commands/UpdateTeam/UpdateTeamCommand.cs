using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Teams.Application.Commands.UpdateTeam
{
    public record UpdateTeamCommand(Guid Id, string Name, string Stadium);
}
