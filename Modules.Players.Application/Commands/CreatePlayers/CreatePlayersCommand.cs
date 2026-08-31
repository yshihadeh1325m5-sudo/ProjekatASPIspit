using System;

namespace Modules.Players.Application.Commands.CreatePlayer
{
    public record CreatePlayerCommand(
        string Name,
        int Age,
        string Position,
        int JerseyNumber,
        Guid TeamId
    );
}