using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Teams.Application.Teams.Commands.CreateTeam;

// Običan record koji samo prenosi podatke poslate sa WPF-a
public record CreateTeamCommand(string Name, string Stadium);